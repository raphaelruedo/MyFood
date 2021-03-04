using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidateAddress();
            ValidateItems();
            ValidateStatus();
            ValidateUserId();
        }

    }
}
