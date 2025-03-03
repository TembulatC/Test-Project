using Domain.Models;
using Domain.Repositories;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDBContext _dbContext;

        public ItemRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddItem(string code, string name, int price, string category)
        {
            var item = new Item(code, name, price, category);

            await _dbContext.Items.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}
