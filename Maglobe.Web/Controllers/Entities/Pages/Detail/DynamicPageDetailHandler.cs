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

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Detail
{
    public class DynamicPageDetailHandler : ApiRequestHandler<DynamicPageDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            
            return ActionResult.Ok(response);
        }
    }
}
