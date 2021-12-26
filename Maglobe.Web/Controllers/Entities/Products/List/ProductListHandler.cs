using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Products.List
{
    public class ProductListHandler : ApiRequestHandler<ProductListRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductListHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductListRequest request)
        {
            var query = _context.Products
                .OrderByDescending(w => w.Id)
                .AsQueryable();

            var response = await query.Select(w =>
            new ProductListResponseItem() {
                Key = w.Id, 
                Title = w.Name,
            }).ToListAsync();
            
            return ActionResult.Ok(response);
        }
    }
}
