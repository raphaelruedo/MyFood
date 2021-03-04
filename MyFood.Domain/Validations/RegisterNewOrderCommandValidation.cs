using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RegisterNewOrderCommandValidation : OrderValidation<RegisterNewOrderCommand>
    {
        public RegisterNewOrderCommandValidation()
        {
            ValidateAddress();
            ValidateItems();
            ValidateStatus();
            ValidateUserId();
        }
    }
}
