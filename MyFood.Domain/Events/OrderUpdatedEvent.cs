using MyFood.Domain.Core.Events;
using MyFood.Domain.Models;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Events
{
    public class OrderUpdatedEvent : Event
    {
        public OrderUpdatedEvent(Guid id, string observation, List<OrderItem> items, Guid userId, Address address, Guid orderStatusId)
        {
            Id = id;
            Observation = observation;
            OrderItens.AddRange(items);
            UserId = userId;
            Address = address;
            OrderStatusId = orderStatusId;

        }

        public Guid Id { get; protected set; }

        public string Observation { get; protected set; }

        public List<OrderItem> OrderItens { get; protected set; }

        public Guid UserId { get; protected set; }

        public Address Address { get; protected set; }

        public Guid OrderStatusId { get; protected set; }
    }
}
