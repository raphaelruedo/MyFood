using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(MyFoodContext context)
            : base(context)
        {

        }

        public async Task<Order> GetOpenOrderByUser(Guid userId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(o => o.UserId == userId);
        }
    }
}
