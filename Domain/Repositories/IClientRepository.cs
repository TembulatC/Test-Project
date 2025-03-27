using Domain.Contracts;
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
        Task AddClient(string login, string password, string code, string email, string phoneNumber);
        Task<Client?> FindClientForAuth(string findData, string data);
        Task<List<Client>> GetAll();
        Task<List<Client>> GetByFilter(string searchInput, string filters, int searchDiscountInput, string sort, int page, int pageSize);
        Task DeleteClient(string code);
        Task UpdateClient(string login, string code, string password, int discount);
    }
}
