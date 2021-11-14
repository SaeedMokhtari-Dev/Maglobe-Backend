using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Maglobe.Core.Api.Handlers;
using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Controllers.Entities.Settings.Add
{
    public class SettingAddHandler : ApiRequestHandler<SettingAddRequest>
    {
        private readonly MaglobeContext _context;
        private readonly IMapper _mapper;
        
        public SettingAddHandler(
            MaglobeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<ActionResult> Execute(SettingAddRequest request)
        {
            Setting setting = await AddSetting(request);
            
            return ActionResult.Ok(ApiMessages.SettingMessage.AddedSuccessfully);
        }
        
        private async Task<Setting> AddSetting(SettingAddRequest request)
        {
            Setting setting = await _context.ExecuteTransactionAsync(async () =>
            {
                Setting newSetting = _mapper.Map<Setting>(request);
                if (!string.IsNullOrEmpty(request.WebsiteLogoImage))
                {
                    newSetting.WebsiteLogo = new Attachment()
                    {
                        CreatedAt = DateTime.Now,
                        Image = request.WebsiteLogoImage.ToCharArray().Select(Convert.ToByte).ToArray()
                    };
                }

                newSetting = (await _context.Settings.AddAsync(newSetting)).Entity;
                await _context.SaveChangesAsync();

                return newSetting;
            });
            return setting;
        }
    }
}