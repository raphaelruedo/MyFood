using FluentValidation;
using MyFood.Domain.Commands;
using System;

namespace MyFood.Domain.Validations
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {
        protected void ValidateUserId()
        {
            RuleFor(o => o.UserId)
                .NotEqual(Guid.Empty).WithMessage("Usuário não pode estar nulo");
        }

        protected void ValidateItems()
        {
            RuleFor(o => o.OrderItens.Count).GreaterThan(0).WithMessage("Pelo menos um produto deve ser selecionado");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateAddress()
        {
            RuleFor(o => o.Address).NotNull().WithMessage("Endereço não pode ser nulo");
        }

        protected void ValidateStatus()
        {
            RuleFor(o => o.OrderStatusId).NotEqual(Guid.Empty).WithMessage("Status não pode ser nulo");
        }
    }
}
