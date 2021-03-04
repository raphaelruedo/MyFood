using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RegisterNewProductCommandValidation : ProductValidation<RegisterNewProductCommand>
    {
        public RegisterNewProductCommandValidation()
        {
            ValidateName();
            ValidateCategory();
            ValidatePrice();
            ValidateRestaurant();
        }
    }
}
