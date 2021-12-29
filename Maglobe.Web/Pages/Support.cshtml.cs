using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maglobe.Core.Enums;
using Maglobe.DataAccess.Contexts;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Pages.Shared;
using Maglobe.Web.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Pages
{
    [AllowAnonymous]
    public class Support : BasePageModel
    {
        private readonly MaglobeContext _maglobeContext;
        public Support(MaglobeContext maglobeContext)
        {
            _maglobeContext = maglobeContext;
        }
        public void OnGet(string siteLanguage)
        {
            Language language = CheckAndSetSiteLanguage(siteLanguage);
            ViewData["BodyClass"] = "support";
        }
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی خود را وارد نمایید.")]
        [BindProperty]
        public string Name { get; set; }
        [Required(ErrorMessage = "لطفا توضیحات خود را وارد نمایید.")]
        [BindProperty]
        public string Description { get; set; }
        [Required(ErrorMessage = "لطفا شماره موبایل خود را وارد نمایید.")]
        [BindProperty]
        public string PhoneNumber { get; set; }

        [BindProperty] 
        public bool Success { get; set; }
        [BindProperty]
        public string ErrorMessage { get; set; }
        public async Task OnPost()
        {
            ViewData["BodyClass"] = "support";
            ErrorMessage = "";
            if (!ModelState.IsValid)
            {
                ErrorMessage = String.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));
                return;
            }

            try
            {
                CustomerSupportRequest support = new CustomerSupportRequest()
                {
                    Name = this.Name,
                    Description = this.Description,
                    PhoneNumber = this.PhoneNumber,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };
                await _maglobeContext.CustomerSupportRequests.AddAsync(support);
                await _maglobeContext.SaveChangesAsync();

                Success = true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }   
        }
    }
}