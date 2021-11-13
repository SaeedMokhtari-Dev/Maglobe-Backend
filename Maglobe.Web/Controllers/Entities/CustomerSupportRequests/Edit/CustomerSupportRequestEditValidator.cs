using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Edit
{
    public class CustomerSupportRequestEditValidator : AbstractValidator<CustomerSupportRequestEditRequest>
    {
        public CustomerSupportRequestEditValidator()
        {
            RuleFor(x => x.CustomerSupportRequestId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
