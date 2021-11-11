using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Auth.GetUserInfo
{
    public class GetUserInfoHandler : ApiRequestHandler<GetUserInfoRequest>
    {
        private readonly MaglobeContext _context;
        private readonly UserContext _userContext;

        public GetUserInfoHandler(MaglobeContext context, UserContext userContext)
        {
            _context = context;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(GetUserInfoRequest request)
        {
            var user = await _context.Users.Include(w => w.Roles).FirstOrDefaultAsync(x => x.Id == _userContext.Id);

            if (user == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            var response = new GetUserInfoResponse
            {
                Id = user.Id,
                Email = user.Email,
                Name = $"{user.FirstName} {user.LastName}",
                Roles = user.Roles.Select(x => x.Role).ToList()
            };

            return ActionResult.Ok(response);
        }
    }
}
