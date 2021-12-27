using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Blogs.Active
{
    public class BlogActiveValidator : AbstractValidator<BlogActiveRequest>
    {
        public BlogActiveValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
