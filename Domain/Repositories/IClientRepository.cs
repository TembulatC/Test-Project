using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClientRepository
    {
        Task AddClient(string login, string password, string code, string address);
        Task<Client> FindClientForAuth(string loginData);
        Task<List<Client>> GetAllByName(bool sort);
        Task<List<Client>> GetAllByCode(bool sort, int page, int pageSize);
        Task<List<Client>> GetAllByDiscount(bool sort);
        Task<List<Client>> GetByFilter(string searchInput, string filters, int searchDiscountInput, string sort);
    }
}
