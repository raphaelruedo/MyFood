using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using MyFood.Application.ViewModels;

namespace MyFood.Application.Interfaces
{
    public interface IRestaurantAppService : IDisposable
    {
        Task<IEnumerable<RestaurantViewModel>> GetAll();
        Task<RestaurantViewModel> GetById(Guid id);

        void Register(RestaurantViewModel restaurantViewModel);
        void Update(RestaurantViewModel restaurantViewModel);
        void Remove(Guid id);
        Task<IEnumerable<RestaurantViewModel>> GetClosest(double latitude, double longitude, double maxDistance);
    }
}
