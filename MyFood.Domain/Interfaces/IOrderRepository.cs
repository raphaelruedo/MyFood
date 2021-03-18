using MyFood.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MyFood.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetOpenOrderByUser(Guid userId);
    }
}
