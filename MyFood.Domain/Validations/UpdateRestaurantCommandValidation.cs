using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class UpdateRestaurantCommandValidation : RestaurantValidation<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateDescription();
            ValidateExpertise();
            ValidateAddress();
        }
    }
}
