using System;
using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Auth.ResetPassword
{
    public class ResetPasswordHandler : ApiRequestHandler<ResetPasswordRequest>
    {
        private readonly MaglobeContext _context;
        private readonly EmailService _emailService;

        public ResetPasswordHandler(
            MaglobeContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        protected override async Task<ActionResult> Execute(ResetPasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.IsActive && x.Email.ToUpper() == request.Email.ToUpper().Trim());

            if(user == null) return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);

            Guid token = await GenerateANewTokenAndSave(user);

            
            await _emailService.SendResetPasswordEmail(user, token);

            return ActionResult.Ok(ApiMessages.Auth.ResetPasswordResponse);
        }

        

        private async Task<Guid> GenerateANewTokenAndSave(User user)
        {
            PasswordResetToken passwordResetToken = 
                await _context.PasswordResetTokens.SingleOrDefaultAsync(w => w.UserId == user.Id);

            if (passwordResetToken != null)
            {
                passwordResetToken.Token = Guid.NewGuid();
                passwordResetToken.ResetRequestDate = DateTime.UtcNow;
            }
            else
            {
                passwordResetToken = new PasswordResetToken()
                {
                    Token = Guid.NewGuid(),
                    UserId = user.Id,
                    ResetRequestDate = DateTime.UtcNow
                };
                await _context.PasswordResetTokens.AddAsync(passwordResetToken);
            }

            await _context.SaveChangesAsync();

            return passwordResetToken.Token;
        }

        /*private async Task SetLastResetPassword(User user)
        {
            user.LastResetPasswordAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }*/
    }
}
