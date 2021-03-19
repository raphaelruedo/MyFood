using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Infra.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(MyFoodContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Restaurant>> GetByName(string name)
        {
            return await DbSet.AsNoTracking().Where(c => c.Name.Contains(name)).ToListAsync();
        }

        public async Task<Restaurant> GetByAddress(string street, int number)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(r => r.Address.Street == street && r.Address.Number == number);
        }

        public async Task<IEnumerable<Restaurant>> GetClosest(double latitude, double longitude, double maxDistance)
        {
            var closest = (from restaurant in   DbSet.AsNoTracking().Include(a=>a.Address)
             let distance = (6371 * Math.Acos(Math.Cos(latitude * Math.PI / 180) * Math.Cos(restaurant.Address.Latitude * Math.PI / 180)
              * Math.Cos((restaurant.Address.Longitude * Math.PI / 180) - (longitude * Math.PI / 180)) + Math.Sin(latitude * Math.PI / 180) *
              Math.Sin(restaurant.Address.Latitude * Math.PI / 180)))
             where distance < maxDistance
             orderby distance
             select restaurant
                                          );
            return await closest.ToListAsync();

        }
    }
}
