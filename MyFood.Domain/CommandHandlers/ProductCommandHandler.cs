using MediatR;
using MyFood.Domain.Commands;
using MyFood.Domain.Core.Bus;
using MyFood.Domain.Core.Notifications;
using MyFood.Domain.Events;
using MyFood.Domain.Interfaces;
using MyFood.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyFood.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand>,
        IRequestHandler<UpdateProductCommand>,
        IRequestHandler<RemoveProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler Bus;

        public ProductCommandHandler(IProductRepository productRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            Bus = bus;
        }

        public async Task<Unit> Handle(RegisterNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            var product = new Product(Guid.NewGuid(), message.Name, message.Description, message.Price, message.RestaurantId, message.CategoryId);

            if (await _productRepository.GetByName(product.Name) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um produto com este nome."));
                return await Unit.Task;
            }

            _productRepository.Add(product);

            if (Commit())
            {
                await Bus.RaiseEvent(new ProductRegisteredEvent(product.Id, product.Name, product.Description, product.Price, product.RestaurantId, product.CategoryId));
            }

            return await Unit.Task;
        }

        public async Task<Unit> Handle(UpdateProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            var product = new Product(message.Id, message.Name, message.Description, message.Price, message.RestaurantId, message.CategoryId);
            var existingProduct = await _productRepository.GetByName(product.Name);

            if (existingProduct != null && existingProduct.Id != product.Id)
            {
                if (!existingProduct.Equals(product))
                {
                    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um produto com este nome"));
                    return await Unit.Task;
                }
            }

            _productRepository.Update(product);

            if (Commit())
            {
                await Bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Description, product.Price, product.RestaurantId,product.CategoryId));
            }

            return await Unit.Task;
        }

        public async Task<Unit> Handle(RemoveProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            _productRepository.Remove(message.Id);

            if (Commit())
            {
                await Bus.RaiseEvent(new ProductRemovedEvent(message.Id));
            }

            return await Unit.Task;
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
