using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task AddItem(string name, int price, string category)
        {
            Random random = new Random();

            string symb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string code = $"{random.Next(10, 99)}-{random.Next(1000, 9999)}-{symb[random.Next(0, 25)]}{symb[random.Next(0, 25)]}{random.Next(10, 99)}";

           await _itemRepository.AddItem(code, name, price, category);
        }
    }
}
