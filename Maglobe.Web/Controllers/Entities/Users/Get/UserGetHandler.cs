using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Users.Get
{
    public class UserGetHandler : ApiRequestHandler<UserGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public UserGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(UserGetRequest request)
        {
            var query = _context.Users.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<UserGetResponseItem>>(result);

            UserGetResponse response = new UserGetResponse();
            response.TotalCount = await _context.Users.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
