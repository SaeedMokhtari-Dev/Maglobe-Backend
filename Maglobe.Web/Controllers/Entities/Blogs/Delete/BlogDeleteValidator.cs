using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Blogs.Delete
{
    public class BlogDeleteValidator : AbstractValidator<BlogDeleteRequest>
    {
        public BlogDeleteValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
