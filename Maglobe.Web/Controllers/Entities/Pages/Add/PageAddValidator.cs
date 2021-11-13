using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Pages.Add
{
    public class PageAddValidator : AbstractValidator<PageAddRequest>
    {
        public PageAddValidator()
        {
        }
    }
}
