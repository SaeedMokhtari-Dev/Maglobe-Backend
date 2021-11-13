using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Add
{
    public class CustomerSupportRequestAddValidator : AbstractValidator<CustomerSupportRequestAddRequest>
    {
        public CustomerSupportRequestAddValidator()
        {
        }
    }
}
