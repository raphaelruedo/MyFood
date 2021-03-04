using FluentValidation;
using MyFood.Domain.Commands;
using System;

namespace MyFood.Domain.Validations
{
    public abstract class RestaurantValidation<T> : AbstractValidator<T> where T : RestaurantCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome não pode estar em branco.")
                .Length(3, 150).WithMessage("O nome precisa ter no mínimo 3 caracteres");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .Length(3, 200).WithMessage("A descrição precisa ter no minimo 3 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateExpertise()
        {
            RuleFor(r => r.ExpertiseId).NotEqual(Guid.Empty).WithMessage("Especilidade não pode ser nula");
        }

        protected void ValidateAddress()
        {
            RuleFor(r => r.Address).NotEmpty().WithMessage("Endereço obrigatório");
        }
    }
}
