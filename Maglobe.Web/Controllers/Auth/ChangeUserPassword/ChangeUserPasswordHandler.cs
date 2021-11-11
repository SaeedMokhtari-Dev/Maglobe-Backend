using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Identity.Contexts;
using Maglobe.Web.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Auth.ChangeUserPassword
{
    public class ChangeUserPasswordHandler : ApiRequestHandler<ChangeUserPasswordRequest>
    {
        private readonly MaglobeContext _context;
        private readonly UserContext _userContext;
        private readonly PasswordService _passwordService;

        public ChangeUserPasswordHandler(
            MaglobeContext context, UserContext userContext, PasswordService passwordService)
        {
            _context = context;
            _userContext = userContext;
            _passwordService = passwordService;
        }

        protected override async Task<ActionResult> Execute(ChangeUserPasswordRequest request)
        {
            if (request.NewPassword != request.ConfirmPassword)
                return ActionResult.Error(ApiMessages.Auth.ChangePasswordNotEqualsPasswords);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.IsActive && x.Id == _userContext.Id);
            if(user == null)
                return ActionResult.Error(ApiMessages.ResourceNotFound);

            if (!_passwordService.IsPasswordValid(request.CurrentPassword, user.Password))
            {
                return ActionResult.Error(ApiMessages.Auth.ChangePasswordCurrentPasswordIsNotCorrect);
            }

            user.Password = _passwordService.GetPasswordHash(request.NewPassword);
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.Auth.ChangePasswordSuccessful);
        }
    }
}
