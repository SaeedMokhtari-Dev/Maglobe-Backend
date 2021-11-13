using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Settings.Delete
{
    public class SettingDeleteHandler : ApiRequestHandler<SettingDeleteRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public SettingDeleteHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SettingDeleteRequest request)
        {
            Setting setting = await _context.Settings
                .FindAsync(request.SettingId);

            if (setting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            await _context.ExecuteTransactionAsync(async () =>
            {
                _context.Settings.Remove(setting);
                await _context.SaveChangesAsync();
            });
            
            return ActionResult.Ok(ApiMessages.SettingMessage.DeletedSuccessfully);
        }
    }
}
