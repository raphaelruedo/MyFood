using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
using System.Linq;

namespace MyFood.Infra.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(MyFoodContext context)
            : base(context)
        {

        }

        public Restaurant GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

        public Restaurant GetByAddress(string street, int number)
        {
            return DbSet.AsNoTracking().FirstOrDefault(r => r.Address.Street == street && r.Address.Number == number);
        }
    }
}
