using AutoMapper;
using MyFood.Application.Interfaces;
using MyFood.Application.ViewModels;
using MyFood.Domain.Commands;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using MyFood.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFood.Application.Services
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
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AddressViewModel, Address>();
                cfg.CreateMap<RestaurantViewModel, RegisterNewRestaurantCommand>();

            });

            var mapper = config.CreateMapper();

            var registerCommand = mapper.Map<RegisterNewRestaurantCommand>(restaurantViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(RestaurantViewModel restaurantViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<AddressViewModel, Address>();
                cfg.CreateMap<RestaurantViewModel, UpdateRestaurantCommand>();

            });

            var mapper = config.CreateMapper();

            var updateCommand = mapper.Map<UpdateRestaurantCommand>(restaurantViewModel);
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
            var closestRestaurants = await _restaurantRepository.GetClosest(latitude, longitude, maxDistance);
            return _mapper.Map<IEnumerable<RestaurantViewModel>>(closestRestaurants);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
