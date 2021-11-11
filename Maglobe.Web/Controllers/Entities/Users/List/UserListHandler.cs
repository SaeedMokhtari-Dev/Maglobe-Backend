using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Identity.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Users.List
{
    public class UserListHandler : ApiRequestHandler<UserListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly UserContext _userContext;

        public UserListHandler(
            MaglobeContext context, IMapper mapper, UserContext userContext)
        {
            _context = context;
            _mapper = mapper;
            _userContext = userContext;
        }

        protected override async Task<ActionResult> Execute(UserListRequest request)
        {
            var query = _context.Users
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new UserListResponseItem() {
                Key = w.Id, 
                FullName = $"{w.FirstName} {w.LastName}",
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
