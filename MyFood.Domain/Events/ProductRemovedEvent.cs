using MyFood.Domain.Core.Events;
using System;

namespace MyFood.Domain.Events
{
    public class ProductRemovedEvent : Event
    {
        public ProductRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
