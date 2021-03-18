using System.Collections.Generic;
using System.Threading.Tasks;
using MyFood.Domain.Models;

namespace MyFood.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByName(string name);
    }
}
