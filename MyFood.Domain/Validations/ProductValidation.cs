using FluentValidation;
using MyFood.Domain.Commands;
using System;

namespace MyFood.Domain.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome não pode estar em branco.")
                .Length(3, 150).WithMessage("O nome precisa ter no mínimo 3 caracteres");
        }

        protected void ValidatePrice()
        {
            RuleFor(p => p.Price)
                .NotNull().WithMessage("O Preço não pode ser vazio");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateRestaurant()
        {
            RuleFor(p => p.RestaurantId).NotEqual(Guid.Empty).WithMessage("Restaurante não pode ser nulo");
        }

        protected void ValidateCategory()
        {
            RuleFor(p => p.CategoryId).NotEqual(Guid.Empty).WithMessage("Categoria não pode ser nula");
        }
    }
}
