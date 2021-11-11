using System;
using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Auth.Login
{
    public class LoginHandler : ApiRequestHandler<LoginRequest>
    {
        private readonly MaglobeContext _context;
        private readonly PasswordService _passwordService;
        private readonly AccessTokenService _accessTokenService;
        private readonly RefreshTokenService _refreshTokenService;

        public LoginHandler(
            MaglobeContext context,
            PasswordService passwordService,
            AccessTokenService accessTokenService,
            RefreshTokenService refreshTokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
        }

        protected override async Task<ActionResult> Execute(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.IsActive && x.Username.ToUpper() == request.Username.ToUpper().Trim());

            if (user == null)
            {
                return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
            }

            if (!IsPasswordValid(request.Password, user.Password))
            {
                return ActionResult.Error(ApiMessages.Auth.InvalidCredentials);
            }

            await SetLastLogin(user);

            return await GetLoginResponse(user);
        }

        private bool IsPasswordValid(string password, string passwordHash)
        {
            return _passwordService.IsPasswordValid(password, passwordHash);
        }

        private async Task<ActionResult> GetLoginResponse(User user)
        {
            var accessToken = _accessTokenService.GenerateAccessToken(user.Id);

            var refreshToken = await _refreshTokenService.GenerateRefreshToken(user.Id);

            var loginResponse = new LoginResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

            return ActionResult.Ok(loginResponse);
        }

        private async Task SetLastLogin(User user)
        {
            user.LastLoginAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
