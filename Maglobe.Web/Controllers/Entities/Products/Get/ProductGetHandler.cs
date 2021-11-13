using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Products.Get
{
    public class ProductGetHandler : ApiRequestHandler<ProductGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductGetRequest request)
        {
            var query = _context.Products.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<ProductGetResponseItem>>(result);

            ProductGetResponse response = new ProductGetResponse();
            response.TotalCount = await _context.Products.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
