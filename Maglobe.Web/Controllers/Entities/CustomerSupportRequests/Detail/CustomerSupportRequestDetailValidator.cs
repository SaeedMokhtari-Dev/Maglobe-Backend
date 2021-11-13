using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Detail
{
    public class CustomerSupportRequestDetailValidator : AbstractValidator<CustomerSupportRequestDetailRequest>
    {
        public CustomerSupportRequestDetailValidator()
        {
            RuleFor(x => x.CustomerSupportRequestId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
