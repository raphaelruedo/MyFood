using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyFood.Application.Interfaces;
using MyFood.Application.ViewModels;
using MyFood.Domain.Commands;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Interfaces;
using MyFood.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFood.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public OrderAppService(IMapper mapper,
                                  IOrderRepository orderRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderRepository.GetAll());
        }

        public async Task<OrderViewModel> GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(await _orderRepository.GetById(id));
        }

        public void Register(OrderViewModel orderViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewOrderCommand>(orderViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(OrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            Bus.SendCommand(removeCommand);
        }

        /*public IList<OrderHistoryData> GetAllHistory(Guid id)
        {
            return OrderHistory.ToJavaScriptOrderHistory(_eventStoreRepository.All(id));
        }*/

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
