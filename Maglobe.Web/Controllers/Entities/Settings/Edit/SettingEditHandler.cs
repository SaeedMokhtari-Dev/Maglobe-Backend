using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Controllers.Entities.Settings.Edit
{
    public class SettingEditHandler : ApiRequestHandler<SettingEditRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;

        public SettingEditHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SettingEditRequest request)
        {
            Setting editSetting = await _context.Settings
                .Include(w => w.WebsiteLogo)
                .FirstOrDefaultAsync(w => w.Id == request.SettingId);

            if (editSetting == null)
            {
                return ActionResult.Error(ApiMessages.ResourceNotFound);
            }

            
            await EditSetting(editSetting, request);
            return ActionResult.Ok(ApiMessages.SettingMessage.EditedSuccessfully);
        }

        private async Task EditSetting(Setting editSetting, SettingEditRequest request)
        {
            await _context.ExecuteTransactionAsync(async () =>
            {
                _mapper.Map(request, editSetting);
                
                if (request.WebsiteLogoImageChanged && !string.IsNullOrEmpty(request.WebsiteLogoImage))
                {
                    editSetting.WebsiteLogo.CreatedAt = DateTime.Now;
                    editSetting.WebsiteLogo.Image = request.WebsiteLogoImage.ToCharArray().Select(Convert.ToByte).ToArray();
                }
                
                await _context.SaveChangesAsync();

                return editSetting;
            });
        }
    }
}