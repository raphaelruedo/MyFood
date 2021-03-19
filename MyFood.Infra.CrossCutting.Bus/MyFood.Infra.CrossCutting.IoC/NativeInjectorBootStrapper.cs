using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyFood.Application.Interfaces;
using MyFood.Application.Services;
using MyFood.Domain.CommandHandlers;
using MyFood.Domain.Commands;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Core.Events;
using MyFood.Domain.EventHandlers;
using MyFood.Domain.Events;
using MyFood.Domain.Interfaces;
using MyFood.Infra.CrossCutting.Bus;
using MyFood.Infra.Data.Context;
using MyFood.Infra.Data.EventSourcing;
using MyFood.Infra.Data.Repository;
using MyFood.Infra.Data.Repository.EventSourcing;
using MyFood.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using MyFood.Domain.Core.Notifications;
using AutoMapper;

namespace MyFood.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRestaurantAppService, RestaurantAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();


            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<RestaurantRegisteredEvent>, RestaurantEventHandler>();
            services.AddScoped<INotificationHandler<RestaurantUpdatedEvent>, RestaurantEventHandler>();
            services.AddScoped<INotificationHandler<RestaurantRemovedEvent>, RestaurantEventHandler>();

            services.AddScoped<INotificationHandler<ProductRegisteredEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<INotificationHandler<ProductRemovedEvent>, ProductEventHandler>();

            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRemovedEvent>, OrderEventHandler>();

            services.AddScoped<IRequestHandler<RegisterNewRestaurantCommand, Unit>, RestaurantCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRestaurantCommand, Unit>, RestaurantCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveRestaurantCommand, Unit>, RestaurantCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewProductCommand, Unit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProductCommand, Unit>, ProductCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewOrderCommand, Unit>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, Unit>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, Unit>, OrderCommandHandler>();

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MyFoodContext>();

            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
            services.AddScoped<IMapper, Mapper>();

        }
    }
}
