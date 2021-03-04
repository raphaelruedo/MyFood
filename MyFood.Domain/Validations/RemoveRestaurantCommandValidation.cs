using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RemoveRestaurantCommandValidation : RestaurantValidation<RemoveRestaurantCommand>
    {
        public RemoveRestaurantCommandValidation()
        {
            ValidateId();
        }
    }
}
