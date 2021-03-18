using AutoMapper;
using MyFood.Application.ViewModels;
using MyFood.Domain.Models;

namespace MyFood.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Restaurant, RestaurantViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderStatus, OrderStatusViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}


