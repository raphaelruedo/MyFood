using MyFood.Domain.Models;

namespace MyFood.Domain.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Restaurant GetByName(string name);
        Restaurant GetByAddress(string street, int number);
    }
}
