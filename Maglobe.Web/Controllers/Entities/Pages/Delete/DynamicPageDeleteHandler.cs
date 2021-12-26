using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    public class DynamicPageDeleteHandler : ApiRequestHandler<DynamicPageDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(DynamicPageDeleteRequest request)
        {
            DynamicPage mage = await _context.DynamicPages
                .FindAsync(request.DynamicPageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.DynamicPages.Remove(mage);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.DynamicPageMessage.DeletedSuccessfully);
        }
    }
}
