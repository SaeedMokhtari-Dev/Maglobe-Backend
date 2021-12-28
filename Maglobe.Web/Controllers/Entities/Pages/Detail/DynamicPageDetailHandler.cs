using System;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    public class DynamicPageDetailHandler : ApiRequestHandler<DynamicPageDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public DynamicPageDetailHandler(
            MaglobeContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        protected override async Task<ActionResult> Execute(DynamicPageDetailRequest request)
        {
            DynamicPage mage = await _context.DynamicPages
                .FirstOrDefaultAsync(w => w.Id == request.DynamicPageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            DynamicPageDetailResponse response = _mapper.Map<DynamicPageDetailResponse>(mage);

            if(_httpContext != null)
                response.Url = $"{_httpContext.HttpContext?.Request?.Scheme}://{_httpContext.HttpContext?.Request?.Host.Value}/Page/{request.DynamicPageId}";
            
            return ActionResult.Ok(response);
        }
    }
}
