using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class UpdateProductCommandValidation : ProductValidation<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidatePrice();
            ValidateCategory();
            ValidateRestaurant();
        }

    }
}
