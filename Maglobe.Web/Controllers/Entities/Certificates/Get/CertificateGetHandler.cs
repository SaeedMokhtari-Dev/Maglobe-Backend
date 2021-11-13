using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Certificates.Get
{
    public class CertificateGetHandler : ApiRequestHandler<CertificateGetRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public CertificateGetHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(CertificateGetRequest request)
        {
            var query = _context.Certificates.OrderByDescending(w => w.Id)
                .Skip(request.PageIndex * request.PageSize).Take(request.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            var mappedResult = _mapper.Map<List<CertificateGetResponseItem>>(result);

            CertificateGetResponse response = new CertificateGetResponse();
            response.TotalCount = await _context.Certificates.CountAsync();
            response.Items = mappedResult;
            return ActionResult.Ok(response);
        }
    }
}
