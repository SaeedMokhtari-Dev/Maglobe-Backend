using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    public class DynamicPageEditHandler : ApiRequestHandler<DynamicPageEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(DynamicPageEditRequest request)
        {
            DynamicPage editDynamicPage = await _context.DynamicPages
                .FirstOrDefaultAsync(w => w.Id == request.DynamicPageId);

            if (editDynamicPage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditDynamicPage(editDynamicPage, request);
            return ActionResult.Ok(ApiMessages.DynamicPageMessage.EditedSuccessfully);
        }

        private async Task EditDynamicPage(DynamicPage editDynamicPage, DynamicPageEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editDynamicPage);
                
                await _context.SaveChangesAsync();

                return editDynamicPage;
            });
        }
    }
}