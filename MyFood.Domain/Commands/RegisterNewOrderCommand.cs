using MyFood.Domain.Models;
using MyFood.Domain.Validations;
using System;
using System.Collections.Generic;

namespace MyFood.Domain.Commands
{
    public class RegisterNewOrderCommand : OrderCommand
    {
        public RegisterNewOrderCommand(string observation, List<OrderItem> items, Guid userId, Address address, Guid orderStatusId)
        {
            Observation = observation;
            UserId = userId;
            Address = address;
            OrderStatusId = OrderStatusId;

            OrderItens = new List<OrderItem>();
            OrderItens.AddRange(items);
            //foreach (var item in items)
            //{
            //    var orderItem = new OrderItem(Guid.NewGuid(), item.ProductId, item.Unit, item.Discount);
            //    OrderItens.Add(item);
            //}

        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
