using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task AddOrderItem(Guid orderId, Guid itemId, int itemCount, int itemPrice);
    }
}
