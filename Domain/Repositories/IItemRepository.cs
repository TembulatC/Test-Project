using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IItemRepository
    {
        Task AddItem(string code, string name, int price, string category);
    }
}
