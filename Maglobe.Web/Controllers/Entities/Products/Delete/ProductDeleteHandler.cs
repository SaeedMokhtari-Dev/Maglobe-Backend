using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Products.Delete
{
    public class ProductDeleteHandler : ApiRequestHandler<ProductDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public ProductDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(ProductDeleteRequest request)
        {
            Product product = await _context.Products
                .FindAsync(request.ProductId);

            if (product == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.ProductMessage.DeletedSuccessfully);
        }
    }
}
