using System.Collections.Generic;
using System.Threading.Tasks;
using MyFood.Domain.Models;

namespace MyFood.Domain.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Task<IEnumerable<Restaurant>> GetByName(string name);
        Task<Restaurant> GetByAddress(string street, int number);
    }
}
