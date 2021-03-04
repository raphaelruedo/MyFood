using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
using System;
using System.Linq;

namespace MyFood.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(MyFoodContext context)
            : base(context)
        {

        }

        public Order GetOpenOrderByUser(Guid userId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(o => o.UserId == userId);
        }
    }
}
