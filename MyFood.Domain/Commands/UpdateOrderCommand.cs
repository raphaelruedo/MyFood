using MyFood.Domain.Models;
using MyFood.Domain.Validations;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Commands
{
    public class UpdateOrderCommand : OrderCommand
    {
        public UpdateOrderCommand(Guid id, string observation, List<OrderItem> items, Guid userId, Address address, Guid orderStatusId)
        {
            Id = id;
            Observation = observation;
            OrderItens.AddRange(items);
            UserId = userId;
            Address = address;
            OrderStatusId = OrderStatusId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
