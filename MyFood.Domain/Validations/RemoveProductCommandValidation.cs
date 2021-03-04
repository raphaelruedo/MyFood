using MyFood.Domain.Commands;

namespace MyFood.Domain.Validations
{
    public class RemoveProductCommandValidation : ProductValidation<RemoveProductCommand>
    {
        public RemoveProductCommandValidation()
        {
            ValidateId();
        }
    }
}
