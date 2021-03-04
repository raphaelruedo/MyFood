using MyFood.Domain.Core.Events;
using System;

namespace MyFood.Domain.Events
{
    public class OrderRemovedEvent : Event
    {
        public OrderRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
