using FluentValidation;

namespace Maglobe.Web.Controllers.Entities.Users.List
{
    public class UserListValidator : AbstractValidator<UserListRequest>
    {
        public UserListValidator()
        {
        }
    }
}
