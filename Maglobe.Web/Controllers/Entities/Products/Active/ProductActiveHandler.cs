using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Products.Active
{
    public class ProductActiveHandler : ApiRequestHandler<ProductActiveRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductActiveHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductActiveRequest request)
        {
            Product product = await _context.Products
                .FindAsync(request.ProductId);

            if (product == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            product.IsActive = true;
            await _context.SaveChangesAsync();
            
            return ActionResult.Ok(ApiMessages.ProductMessage.ActivatedSuccessfully);
        }
    }
}
