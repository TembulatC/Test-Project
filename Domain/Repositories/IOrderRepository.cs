using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrder(Guid clientId, DateTime shipmentDate, int orderNumber, string status);
    }
}
