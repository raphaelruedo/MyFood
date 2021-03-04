using MyFood.Domain.Core.Commands;
using MyFood.Domain.Models;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Commands
{
    public abstract class RestaurantCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        public bool IsActive { get; protected set; }

        public Guid ExpertiseId { get; protected set; }

        public Address Address { get; protected set; }

        public List<Product> Products { get; protected set; }

    }
}
