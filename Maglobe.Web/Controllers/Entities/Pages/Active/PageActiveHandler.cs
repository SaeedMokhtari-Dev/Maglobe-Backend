using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Pages.Active
{
    public class PageActiveHandler : ApiRequestHandler<PageActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageActiveRequest request)
        {
            Page mage = await _context.Pages
                .FindAsync(request.PageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            mage.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.PageMessage.ActivatedSuccessfully);
        }
    }
}
