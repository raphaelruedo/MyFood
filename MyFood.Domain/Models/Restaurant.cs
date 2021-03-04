using MyFood.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Models
{
    public class Restaurant : Entity
    {
        public Restaurant(Guid id, string name, string description, bool isActive, Guid expertiseId,
            Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            ExpertiseId = expertiseId;
            Address = address;
        }

        protected Restaurant() { }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Guid ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }

        public List<Product> Products { get; set; }
    }
}
