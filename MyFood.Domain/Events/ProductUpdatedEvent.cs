using MyFood.Domain.Core.Events;
using System;

namespace MyFood.Domain.Events
{
    public class ProductUpdatedEvent : Event
    {
        public ProductUpdatedEvent(Guid id, string name, string description, decimal price, Guid restaurantId, Guid categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            RestaurantId = restaurantId;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public Guid RestaurantId { get; private set; }

        public Guid CategoryId { get; private set; }
    }
}
