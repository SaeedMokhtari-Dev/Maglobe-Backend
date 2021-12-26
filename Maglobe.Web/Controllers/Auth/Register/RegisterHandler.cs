using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Auth.Register
{
    public class RegisterHandler : ApiRequestHandler<RegisterRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;
        private readonly AccessTokenService _accessTokenService;
        private readonly RefreshTokenService _refreshTokenService;

        public RegisterHandler(
            MaglobeContext context,
            PasswordService passwordService,
            AccessTokenService accessTokenService,
            RefreshTokenService refreshTokenService, IMapper mapper)
        {
            _context = context;
            _passwordService = passwordService;
            _accessTokenService = accessTokenService;
            _refreshTokenService = refreshTokenService;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(RegisterRequest request)
        {
            var isUsernameDuplicate =
                _context.Users.Any(w => w.Username.Trim().ToUpper() == request.Username.Trim().ToUpper());
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }
            
            if (!string.IsNullOrEmpty(request.Email))
            {
                var isEmailDuplicate =
                    _context.Users.Any(w => w.Email.Trim().ToUpper() == request.Email.Trim().ToUpper());
                if (isEmailDuplicate)
                {
                    return ActionResult.Error(ApiMessages.DuplicateEmail);
                }
            }
            User user = await RegisterUser(request);
            
            return ActionResult.Ok(ApiMessages.UserMessage.RegisteredSuccessfully);
        }
        private async Task<User> RegisterUser(RegisterRequest request)
        {
            User user = await _context.ExecuteTransactionAsync(async () =>
            {
                User newUser = _mapper.Map<User>(request);

                newUser.Password = _passwordService.GetPasswordHash(request.Password);
                
                newUser.Roles.Add(new UserRole()
                {
                    Role = RoleType.User
                });
                
                newUser = (await _context.Users.AddAsync(newUser)).Entity;
                await _context.SaveChangesAsync();

                return newUser;
            });
            return user;
        }
    }
}
