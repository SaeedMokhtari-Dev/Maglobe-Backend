using System;
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
using Maglobe.Web.Identity.Services;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Edit
{
    public class PageEditHandler : ApiRequestHandler<PageEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageEditRequest request)
        {
            Page editPage = await _context.Pages
                .FirstOrDefaultAsync(w => w.Id == request.PageId);

            if (editPage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditPage(editPage, request);
            return ActionResult.Ok(ApiMessages.PageMessage.EditedSuccessfully);
        }

        private async Task EditPage(Page editPage, PageEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editPage);
                
                await _context.SaveChangesAsync();

                return editPage;
            });
        }
    }
}