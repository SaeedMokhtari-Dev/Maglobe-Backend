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

namespace Maglobe.Web.Controllers.Entities.Users.Add
{
    public class UserAddHandler : ApiRequestHandler<UserAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;
        
        public UserAddHandler(
            MaglobeContext context, IMapper mapper, PasswordService passwordService)
        {
            _context = context;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        protected override async Task<ActionResult> Execute(UserAddRequest request)
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
            User user = await AddUser(request);
            
            return ActionResult.Ok(ApiMessages.UserMessage.AddedSuccessfully);
        }
        
        private async Task<User> AddUser(UserAddRequest request)
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