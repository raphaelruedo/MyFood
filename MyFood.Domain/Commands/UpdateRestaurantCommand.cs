using MyFood.Domain.Validations;
using System;

namespace MyFood.Domain.Commands
{
    public class UpdateRestaurantCommand : RestaurantCommand
    {
        public UpdateRestaurantCommand(Guid id, string name, string description, bool isActive, Guid expertiseId)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = IsActive;
            ExpertiseId = expertiseId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRestaurantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
