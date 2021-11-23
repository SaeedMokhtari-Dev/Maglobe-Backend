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

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Add
{
    public class DynamicPageAddHandler : ApiRequestHandler<DynamicPageAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public DynamicPageAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(DynamicPageAddRequest request)
        {
            DynamicPage mage = await AddDynamicPage(request);
            
            return ActionResult.Ok(ApiMessages.DynamicPageMessage.AddedSuccessfully);
        }
        
        private async Task<DynamicPage> AddDynamicPage(DynamicPageAddRequest request)
        {
            DynamicPage mage = await _context.ExecuteTransactionAsync(async () =>
            {
                DynamicPage newDynamicPage = _mapper.Map<DynamicPage>(request);

                newDynamicPage = (await _context.DynamicPages.AddAsync(newDynamicPage)).Entity;
                await _context.SaveChangesAsync();

                return newDynamicPage;
            });
            return mage;
        }
    }
}