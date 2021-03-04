using MediatR;
using MyFood.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MyFood.Domain.EventHandlers
{
    public class OrderEventHandler :
            INotificationHandler<OrderRegisteredEvent>,
            INotificationHandler<OrderUpdatedEvent>,
            INotificationHandler<OrderRemovedEvent>
    {
        public Task Handle(OrderUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
