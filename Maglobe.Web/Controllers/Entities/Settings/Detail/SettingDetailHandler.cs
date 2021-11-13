using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Settings.Detail
{
    public class SettingDetailHandler : ApiRequestHandler<SettingDetailRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public SettingDetailHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SettingDetailRequest request)
        {
            Setting setting = await _context.Settings
                .FirstOrDefaultAsync(w => w.Id == request.SettingId);

            if (setting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            SettingDetailResponse response = _mapper.Map<SettingDetailResponse>(setting);
            
            return ActionResult.Ok(response);
        }
    }
}
