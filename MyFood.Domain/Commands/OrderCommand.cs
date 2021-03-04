using MyFood.Domain.Core.Commands;
using MyFood.Domain.Models;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Commands
{
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Observation { get; protected set; }

        public List<OrderItem> OrderItens { get; protected set; }

        public Guid UserId { get; protected set; }

        public Address Address { get; protected set; }

        public Guid OrderStatusId { get; protected set; }
    }
}
