using AutoMapper;
using MyFood.Application.ViewModels;
using MyFood.Domain.Commands;
using MyFood.Domain.Models;
using System.Collections.Generic;

namespace MyFood.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        private readonly IMapper _mapper;

        public ViewModelToDomainMappingProfile(IMapper mapper)
        {
            _mapper = mapper;

            //Restaurants
            CreateMap<RestaurantViewModel, RegisterNewRestaurantCommand>()
                .ConstructUsing(r => new RegisterNewRestaurantCommand(r.Name, r.Description, r.IsActive, r.ExpertiseId, _mapper.Map<AddressViewModel, Address>(r.Address)));

            CreateMap<RestaurantViewModel, UpdateRestaurantCommand>()
                .ConstructUsing(r => new UpdateRestaurantCommand(r.Id, r.Name, r.Description, r.IsActive, r.ExpertiseId));

            //PRoducts
            CreateMap<ProductViewModel, RegisterNewProductCommand>()
                .ConstructUsing(product => new RegisterNewProductCommand(product.Name, product.Description, product.Price, product.RestaurantId, product.CategoryId));

            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(product => new UpdateProductCommand(product.Id, product.Name, product.Description, product.Price, product.RestaurantId, product.CategoryId));


            //Order
            CreateMap<OrderViewModel, RegisterNewOrderCommand>()
               .ConstructUsing(order => new RegisterNewOrderCommand(order.Observation, _mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(order.OrderItens), order.UserId, _mapper.Map<AddressViewModel, Address>(order.Address), order.OrderStatusId));

            CreateMap<OrderViewModel, UpdateOrderCommand>()
                .ConstructUsing(order => new UpdateOrderCommand(order.Id, order.Observation, _mapper.Map<List<OrderItemViewModel>, List<OrderItem>>(order.OrderItens), order.UserId, _mapper.Map<AddressViewModel, Address>(order.Address), order.OrderStatusId));

        }
    }
}
