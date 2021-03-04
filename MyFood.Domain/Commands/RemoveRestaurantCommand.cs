using MyFood.Domain.Validations;
using System;

namespace MyFood.Domain.Commands
{
    public class RemoveRestaurantCommand : RestaurantCommand
    {
        public RemoveRestaurantCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveRestaurantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
