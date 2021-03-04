using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RemoveOrderCommandValidation : OrderValidation<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidation()
        {
            ValidateId();
        }
    }
}
