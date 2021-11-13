using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Delete
{
    public class CustomerSupportRequestDeleteValidator : AbstractValidator<CustomerSupportRequestDeleteRequest>
    {
        public CustomerSupportRequestDeleteValidator()
        {
            RuleFor(x => x.CustomerSupportRequestId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
