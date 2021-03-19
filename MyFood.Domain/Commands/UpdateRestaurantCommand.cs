using MyFood.Domain.Models;
using MyFood.Domain.Validations;
using System;

namespace MyFood.Domain.Commands
{
    public class UpdateRestaurantCommand : RestaurantCommand
    {
        public UpdateRestaurantCommand(Guid id, string name, string description, bool isActive, Guid expertiseId, Address address)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
            ExpertiseId = expertiseId;
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRestaurantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
