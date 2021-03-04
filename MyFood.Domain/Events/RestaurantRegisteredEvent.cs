using MyFood.Domain.Core.Events;
using MyFood.Domain.Models;
using System;

namespace MyFood.Domain.Events
{
    public class RestaurantRegisteredEvent : Event
    {
        public RestaurantRegisteredEvent(Guid id, string name, string description, bool isActive, Guid expertiseId,
            Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            AggregateId = id;
            ExpertiseId = expertiseId;
            Address = address;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsActive { get; private set; }

        public Guid ExpertiseId { get; private set; }

        public Address Address { get; private set; }
    }
}
