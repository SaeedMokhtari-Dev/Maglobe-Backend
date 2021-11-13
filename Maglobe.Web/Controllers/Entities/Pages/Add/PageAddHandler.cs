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
using Maglobe.Web.Identity.Services;

namespace Maglobe.Web.Controllers.Entities.Pages.Add
{
    public class PageAddHandler : ApiRequestHandler<PageAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public PageAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(PageAddRequest request)
        {
            Page mage = await AddPage(request);
            
            return ActionResult.Ok(ApiMessages.PageMessage.AddedSuccessfully);
        }
        
        private async Task<Page> AddPage(PageAddRequest request)
        {
            Page mage = await _context.ExecuteTransactionAsync(async () =>
            {
                Page newPage = _mapper.Map<Page>(request);

                newPage = (await _context.Pages.AddAsync(newPage)).Entity;
                await _context.SaveChangesAsync();

                return newPage;
            });
            return mage;
        }
    }
}