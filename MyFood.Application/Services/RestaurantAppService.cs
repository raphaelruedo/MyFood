using AutoMapper;
using MyFood.Application.Interfaces;
using MyFood.Application.ViewModels;
using MyFood.Domain.Commands;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Interfaces;
using MyFood.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Next3.Application.Services
{
    public class RestaurantAppService : IRestaurantAppService
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public RestaurantAppService(IMapper mapper,
                                  IRestaurantRepository restaurantRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<RestaurantViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<RestaurantViewModel>>(await _restaurantRepository.GetAll());
        }

        public async Task<RestaurantViewModel> GetById(Guid id)
        {
            return _mapper.Map<RestaurantViewModel>(await _restaurantRepository.GetById(id));
        }

        public void Register(RestaurantViewModel restaurantViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewRestaurantCommand>(restaurantViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(RestaurantViewModel restaurantViewModel)
        {
            var updateCommand = _mapper.Map<UpdateRestaurantCommand>(restaurantViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveRestaurantCommand(id);
            Bus.SendCommand(removeCommand);
        }

        /*public IList<RestaurantHistoryData> GetAllHistory(Guid id)
        {
            return RestaurantHistory.ToJavaScriptRestaurantHistory(_eventStoreRepository.All(id));
        }*/

        public async Task<IEnumerable<RestaurantViewModel>> GetClosest(double latitude, double longitude, double maxDistance)
        {
            var closestRestaurants = (from restaurant in await _restaurantRepository.GetAll()
                                      let distance = (6371 * Math.Acos(Math.Cos(latitude * Math.PI / 180) * Math.Cos(restaurant.Address.Latitude * Math.PI / 180)
                                       * Math.Cos((restaurant.Address.Longitude * Math.PI / 180) - (longitude * Math.PI / 180)) + Math.Sin(latitude * Math.PI / 180) *
                                       Math.Sin(restaurant.Address.Latitude * Math.PI / 180)))
                                      where distance < maxDistance
                                      orderby distance
                                      select restaurant
                                          );

            return _mapper.Map<IEnumerable<RestaurantViewModel>>(closestRestaurants);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
