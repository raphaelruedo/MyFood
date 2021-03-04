using MyFood.Domain.Models;
using System;

namespace MyFood.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOpenOrderByUser(Guid userId);
    }
}
