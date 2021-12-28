using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    public class DynamicPageGetHandler : ApiRequestHandler<DynamicPageGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DynamicPageGetHandler(
            MaglobeContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        protected override async Task<ActionResult> Execute(DynamicPageGetRequest request)
        {
            var query = _context.DynamicPages.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<DynamicPageGetResponseItem>>(result);

            DynamicPageGetResponse response = new DynamicPageGetResponse();
            response.TotalCount = await _context.DynamicPages.CountAsync();
            response.Items = mappedResult;
            if(_httpContext != null)
                response.Items.ForEach(w => w.Url = $"{_httpContext.HttpContext?.Request?.Scheme}://{_httpContext.HttpContext?.Request?.Host.Value}/Page/{w.Key}");
            return ActionResult.Ok(response);
        }
    }
}
