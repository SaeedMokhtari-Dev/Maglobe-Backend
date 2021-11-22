using System;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Contexts;
using Maglobe.Web.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace Maglobe.Web.Services
{
    public class PageService: ITransient
    {
        private readonly MaglobeContext _context;

        public PageService(MaglobeContext context)
        {
            _context = context;
        }

        public async Task<PageViewModel> GetPage(Language language, long pageKey)
        {
            var page = await _context.Pages
                .FirstOrDefaultAsync(w => w.IsActive && w.Language == language.ToString() && w.Id == pageKey);

            if (page == null)
                throw new Exception("Page Not Found");

            return new PageViewModel()
            {
                Title = page.Title,
                Editor = page.Editor,
                DescriptionSeo = page.DescriptionSeo
            };
        }
    }
}