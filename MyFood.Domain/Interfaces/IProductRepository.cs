using MyFood.Domain.Models;

namespace MyFood.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
    }
}
