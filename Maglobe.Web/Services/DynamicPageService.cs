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

        public async Task<DynamicPageViewModel> GetDynamicPage(Language language, long DynamicPageKey)
        {
            var DynamicPage = await _context.DynamicPages
                .FirstOrDefaultAsync(w => w.IsActive && w.Language == language.ToString() && w.Id == DynamicPageKey);

            if (DynamicPage == null)
                throw new Exception("DynamicPage Not Found");

            return new DynamicPageViewModel()
            {
                Title = DynamicPage.Title,
                Editor = DynamicPage.Editor,
                DescriptionSeo = DynamicPage.DescriptionSeo
            };
        }
    }
}