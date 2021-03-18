using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Context;
using System.Threading.Tasks;

namespace MyFood.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyFoodContext context)
            : base(context)
        {

        }

        public async Task<Product> GetByName(string name)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
