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


        // Получение списка клиентов
        public async Task<List<Client>> GetAllByName(bool sort)
        {
            switch(sort)
            {
                case true:
                    return await _dbContext.Clients.AsNoTracking().OrderBy(c => c.Name).ToListAsync();

                case false:
                    return await _dbContext.Clients.AsNoTracking().OrderByDescending(c => c.Name).ToListAsync();
            }
        }

        public async Task<List<Client>> GetAllByCode(bool sort, int page, int pageSize)
        {
            switch (sort)
            {
                case true:
                    return await _dbContext.Clients.AsNoTracking()
                        .OrderBy(c => c.Code)
                        .Take(pageSize)
                        .ToListAsync();

                case false:
                    return await _dbContext.Clients.AsNoTracking()
                        .OrderByDescending(c => c.Code)
                        .Take(pageSize)
                        .ToListAsync();
            }
        }

        public async Task<List<Client>> GetAllByDiscount(bool sort)
        {
            switch (sort)
            {
                case true:
                    return await _dbContext.Clients.AsNoTracking().OrderBy(c => c.Discount).ToListAsync();

                case false:
                    return await _dbContext.Clients.AsNoTracking().OrderByDescending(c => c.Discount).ToListAsync();
            }
        }

        public async Task<List<Client>> GetByFilter(string searchInput, string filter, int searchDiscountInput, string sort)
        {
            var clients = _dbContext.Clients.AsNoTracking();

            Expression<Func<Client, bool>> filters = filter?.ToLower() switch
            {
                "name" => c => c.Name.ToLower().Contains(searchInput.ToLower()),
                "code" => c => c.Code.ToLower().Contains(searchInput.ToLower()),
                "address" => c => c.Address.ToLower().Contains(searchInput.ToLower()),
                "discount" => c => c.Discount == searchDiscountInput
            };

            Expression<Func<Client, object>> sorting = filter?.ToLower() switch
            {
                "name" => c => c.Name,
                "code" => c => c.Code,
                "address" => c => c.Address,
                "discount" => c => c.Discount
            };

            Expression<Func<Client, object>> sortings = filter?.ToLower() switch
            {
                "name" => c => c.Name,
                "code" => c => c.Code,
                "address" => c => c.Address,
                "discount" => c => c.Discount
            };

            if (!string.IsNullOrWhiteSpace(searchInput) && sort == "asc")
            {
                clients = clients.Where(filters).OrderBy(sorting);

            }

            else if (!string.IsNullOrWhiteSpace(searchInput) && sort == "desc")
            {
                clients = clients.Where(filters).OrderByDescending(sorting);
            }

            return await clients.ToListAsync();
        }
    }
}
