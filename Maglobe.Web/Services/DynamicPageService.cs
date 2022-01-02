using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class DynamicPageService: ITransient
    {
        private readonly MaglobeContext _context;

        public DynamicPageService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<DynamicPageViewModel> GetDynamicPage(Language language, long dynamicPageKey)
        {
            var dynamicPage = await _context.DynamicPages
                .FirstOrDefaultAsync(w => w.IsActive && w.Language == language.ToString() && w.Id == dynamicPageKey);

            if (dynamicPage == null)
                return new DynamicPageViewModel();

            return new DynamicPageViewModel()
            {
                Title = dynamicPage.Title,
                Editor = dynamicPage.Editor,
                DescriptionSeo = dynamicPage.DescriptionSeo
            };
        }
    }
}