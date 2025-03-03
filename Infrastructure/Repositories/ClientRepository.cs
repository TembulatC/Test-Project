using Domain.Repositories;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq.Expressions;
using NUglify.JavaScript.Syntax;

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
        public async Task AddClient(string name, string password, string code, string address)
        {
            var client = new Client(name, password, code, address);

            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }

        // Поиск клиента из базы данных
        public async Task<Client> FindClientForAuth(string loginData)
        {
            var client = await _dbContext.Clients.AsNoTracking().FirstOrDefaultAsync(c => c.Name == loginData);

            return client;
        }

        private IQueryable<Client> GetByOrder(string searchInput, string filter, string sort, int pageSize, IQueryable<Client> clients)
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
                    clientsFilters = clientsFilters.OrderBy(sorting).Take(pageSize);
                    break;

                case "desc":
                    clientsFilters = clientsFilters.OrderByDescending(sorting).Take(pageSize);
                    break;
            }

            return clientsFilters;
        }

        public async Task<List<Client>> GetByFilter(string searchInput, string filter, int searchDiscountInput, string sort, int pageSize)
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
                    clients = GetByOrder(searchInput, filter, sort, pageSize, clients.Where(filters));
                    break;

                case true:
                    clients = clients.OrderByDescending(c => c.Code).Take(pageSize);
                    break;

            }

            return await clients.ToListAsync();
        }
    }
}
