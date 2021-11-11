using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Identity.Contexts;
using Maglobe.Web.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Users.Edit
{
    public class UserEditHandler : ApiRequestHandler<UserEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly PasswordService _passwordService;
        private readonly UserContext _userContext;

        public UserEditHandler(
            MaglobeContext context, IMapper mapper, PasswordService passwordService, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _passwordService = passwordService;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(UserEditRequest request)
        {
            if (_userContext.Roles.Any(w => w.Role == RoleType.User) && request.UserId != _userContext.Id)
            {
                return ActionResult.Error(ApiMessages.Forbidden);
            }
            User editUser = await _context.Users
                .Include(w => w.Roles)
                .FirstOrDefaultAsync(w => w.Id == request.UserId);

            if (editUser == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            var isUsernameDuplicate =
                _context.Users.Any(w => w.Username.Trim().ToUpper() == request.Username.Trim().ToUpper()
                                        && w.Id != request.UserId);
            if (isUsernameDuplicate)
            {
                return ActionResult.Error(ApiMessages.DuplicateUserName);
            }
            
            if (!string.IsNullOrEmpty(request.Email))
            {
                var isEmailDuplicate =
                    _context.Users.Any(w => w.Email.Trim().ToUpper() == request.Email.Trim().ToUpper()
                                            && w.Id != request.UserId);
                if (isEmailDuplicate)
                {
                    return ActionResult.Error(ApiMessages.DuplicateEmail);
                }
            }

            await EditUser(editUser, request);
            return ActionResult.Ok(ApiMessages.UserMessage.EditedSuccessfully);
        }

        private async Task EditUser(User editUser, UserEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                //User newUser = _mapper.Map<User>(request);
                _mapper.Map(request, editUser);

                if(request.PasswordChanged)
                    editUser.Password = _passwordService.GetPasswordHash(request.Password);

                //editUser = (await _context.Users.AddAsync(editUser)).Entity;
                await _context.SaveChangesAsync();

                return editUser;
            });
        }
    }
}