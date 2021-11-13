using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Get
{
    public class CustomerSupportRequestGetValidator : AbstractValidator<CustomerSupportRequestGetRequest>
    {
        public CustomerSupportRequestGetValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageSize);
            RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(0).WithMessage(ApiMessages.PageIndex);
        }
    }
}
