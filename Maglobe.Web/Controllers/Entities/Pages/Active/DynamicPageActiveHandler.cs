using System.Threading.Tasks;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Pages.Active
{
    public class DynamicPageActiveHandler : ApiRequestHandler<DynamicPageActiveRequest>
    {
        private readonly MaglobeContext _context;

        public DynamicPageActiveHandler(MaglobeContext context)
        {
            _context = context;
        }

        protected override async Task<ActionResult> Execute(DynamicPageActiveRequest request)
        {
            DynamicPage mage = await _context.DynamicPages
                .FindAsync(request.DynamicPageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            mage.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.DynamicPageMessage.ActivatedSuccessfully);
        }
    }
}
