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

namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    public class PageDetailHandler : ApiRequestHandler<PageDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageDetailRequest request)
        {
            Page mage = await _context.Pages
                .FirstOrDefaultAsync(w => w.Id == request.PageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            PageDetailResponse response = _mapper.Map<PageDetailResponse>(mage);
            
            return ActionResult.Ok(response);
        }
    }
}
