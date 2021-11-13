using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Pages.Delete
{
    public class PageDeleteHandler : ApiRequestHandler<PageDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageDeleteRequest request)
        {
            Page mage = await _context.Pages
                .FindAsync(request.PageId);

            if (mage == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Pages.Remove(mage);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.PageMessage.DeletedSuccessfully);
        }
    }
}
