using MyFood.Domain.Core.Events;
using System;

namespace MyFood.Domain.Events
{
    public  class RestaurantRemovedEvent : Event
    {
        public RestaurantRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
