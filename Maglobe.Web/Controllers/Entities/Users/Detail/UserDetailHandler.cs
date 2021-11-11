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
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Users.Detail
{
    public class UserDetailHandler : ApiRequestHandler<UserDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public UserDetailHandler(
            MaglobeContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(UserDetailRequest request)
        {
            if (_userContext.Roles.Any(w => w.Role == RoleType.User) && request.UserId != _userContext.Id)
            {
                return ActionResult.Error(ApiMessages.Forbidden);
            }
            User user = await _context.Users
                .Include(w => w.Roles)
                .FirstOrDefaultAsync(w => w.Id == request.UserId);

            if (user == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            UserDetailResponse response = _mapper.Map<UserDetailResponse>(user);
            
            return ActionResult.Ok(response);
        }
    }
}
