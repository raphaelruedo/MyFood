using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
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
    }
}
