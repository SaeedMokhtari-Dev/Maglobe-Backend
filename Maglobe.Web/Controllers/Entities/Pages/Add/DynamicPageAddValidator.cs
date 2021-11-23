using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Add
{
    public class DynamicPageAddValidator : AbstractValidator<DynamicPageAddRequest>
    {
        public DynamicPageAddValidator()
        {
        }
    }
}
