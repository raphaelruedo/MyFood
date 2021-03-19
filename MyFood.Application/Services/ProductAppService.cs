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
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        }

        public void Register(ProductViewModel productViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(productViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ProductViewModel productViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(productViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }

       /* public IList<ProductHistoryData> GetAllHistory(Guid id)
        {
            return ProductHistory.ToJavaScriptProductHistory(_eventStoreRepository.All(id));
        }*/

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
