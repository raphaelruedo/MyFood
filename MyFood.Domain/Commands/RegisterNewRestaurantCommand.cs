using MyFood.Domain.Models;
using MyFood.Domain.Validations;
using System;

namespace MyFood.Domain.Commands
{
    public class RegisterNewRestaurantCommand : RestaurantCommand
    {
        public RegisterNewRestaurantCommand(string name, string description, bool isActive, Guid expertiseId,
            Address address)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            ExpertiseId = expertiseId;
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewRestaurantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

}
