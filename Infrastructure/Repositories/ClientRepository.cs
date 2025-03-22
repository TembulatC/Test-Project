using Domain.Repositories;
using Domain.Models;
using Infrastructure.Context;
using System;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    // Слой работы с данными
    public class ClientRepository : IClientRepository
    {
        private readonly AppDBContext _dbContext;

        public ClientRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }

        // Добавление клиента в базу данных
        public async Task AddClient(string name, string password, string code, string address, string email, string phoneNumber)
        {
            var client = new Client(name, password, code, address, email, phoneNumber);

            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        // Поиск клиента из базы данных
        public async Task<Client> FindClientForAuth(string loginData)
        {
            var client = await _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Name == loginData);

            return client;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _dbContext.Clients
                .AsNoTracking()
                .OrderByDescending(c => c.Code)
                .ToListAsync();
        }

        private IQueryable<Client> GetByOrder(string filter, string sort, IQueryable<Client> clients)
        {
            Expression<Func<Client, object>> sorting = filter?.ToLower() switch
            {
                "name" => c => c.Name,
                "code" => c => c.Code,
                "address" => c => c.Address,
                "discount" => c => c.Discount
            };

            var clientsFilters = clients;

            switch(sort)
            {
                case "asc":
                    clientsFilters = clientsFilters.OrderBy(sorting);
                    break;

                case "desc":
                    clientsFilters = clientsFilters.OrderByDescending(sorting);
                    break;
            }

            return clientsFilters;
        }

        public async Task<List<Client>> GetByFilter(string searchInput, string filter, int searchDiscountInput, string sort, int page, int pageSize)
        {
            var clients = _dbContext.Clients.AsNoTracking();

            Expression<Func<Client, bool>> filters = filter?.ToLower() switch
            {
                "name" => c => c.Name.ToLower().Contains(searchInput.ToLower()),
                "code" => c => c.Code.ToLower().Contains(searchInput.ToLower()),
                "address" => c => c.Address.ToLower().Contains(searchInput.ToLower()),
                "discount" => c => c.Discount == searchDiscountInput
            };

            switch (string.IsNullOrWhiteSpace(searchInput))
            {
                case false:
                    clients = GetByOrder(filter, sort, clients.Where(filters));
                    break;

                case true:
                    clients = GetByOrder(filter, sort, clients);
                    break;
            }

            return await clients.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task DeleteClient(string code)
        {
            await _dbContext.Clients.Where(c => c.Code == code).ExecuteDeleteAsync();         
        }

        public async Task UpdateClient(string login, string code, string password, int discount)
        {
            await _dbContext.Clients.Where(c => c.Code == code)
                .ExecuteUpdateAsync(u => u
                .SetProperty(c => c.Name, login)
                .SetProperty(c => c.Password, password)
                .SetProperty(c => c.Discount, discount));
        }
    }
}
