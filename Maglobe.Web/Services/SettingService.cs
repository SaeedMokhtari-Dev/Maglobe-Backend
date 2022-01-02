using System;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class SettingService: ITransient
    {
        private readonly MaglobeContext _context;

        public SettingService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<SettingViewModel> GetSetting(Language language)
        {
            var setting = await _context.Settings
                .FirstOrDefaultAsync(w => w.Language == language.ToString());

            if (setting == null)
                return new SettingViewModel();

            return new SettingViewModel()
            {
                WebsiteLogo = String.Join("", setting.WebsiteLogo.Image.Select(Convert.ToChar)),
                WebsiteTitle = setting.WebsiteTitle
            };
        }
    }
}