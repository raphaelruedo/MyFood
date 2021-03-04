using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RegisterNewRestaurantCommandValidation : RestaurantValidation<RegisterNewRestaurantCommand>
    {
        public RegisterNewRestaurantCommandValidation()
        {
            ValidateName();
            ValidateDescription();
            ValidateExpertise();
            ValidateAddress();
        }
    }
}
