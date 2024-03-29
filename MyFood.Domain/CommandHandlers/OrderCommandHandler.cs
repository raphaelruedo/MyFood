﻿using MediatR;
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
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewOrderCommand>,
        IRequestHandler<UpdateOrderCommand>,
        IRequestHandler<RemoveOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IOrderRepository orderRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _orderRepository = orderRepository;
            Bus = bus;
        }

        public async Task<Unit> Handle(RegisterNewOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            var order = new Order(Guid.NewGuid(), message.UserId, message.Address, message.OrderItens, message.Observation, message.OrderStatusId);

            if (_orderRepository.GetOpenOrderByUser(order.UserId) != null)
            {
                await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um pedido em aberto para este usuário"));
                return await Unit.Task;
            }

            _orderRepository.Add(order);

            if (Commit())
            {
                await Bus.RaiseEvent(new OrderRegisteredEvent(order.Id, order.Observation, order.OrderItens, order.UserId, order.Address, order.OrderStatusId));
            }

            return await Unit.Task;
        }

        public async Task<Unit> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            var order = new Order(Guid.NewGuid(), message.UserId, message.Address, message.OrderItens, message.Observation, message.OrderStatusId);
            var existingOrder = await _orderRepository.GetOpenOrderByUser(order.UserId);

            if (existingOrder != null && existingOrder.Id != order.Id)
            {
                if (!existingOrder.Equals(order))
                {
                    await Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um pedido em aberto para este usuário"));
                    return await Unit.Task;
                }
            }

            _orderRepository.Update(order);

            if (Commit())
            {
                await Bus.RaiseEvent(new OrderUpdatedEvent(order.Id, order.Observation, order.OrderItens, order.UserId, order.Address, order.OrderStatusId));
            }

            return await Unit.Task;
        }

        public async Task<Unit> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return await Unit.Task;
            }

            _orderRepository.Remove(message.Id);

            if (Commit())
            {
                await Bus.RaiseEvent(new OrderRemovedEvent(message.Id));
            }

            return await Unit.Task;
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}
