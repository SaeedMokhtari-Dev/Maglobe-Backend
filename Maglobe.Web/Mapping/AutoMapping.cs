using System;
using System.Linq;
using AutoMapper;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Controllers.Auth.Register;
using Maglobe.Web.Controllers.Entities.Blogs.Add;
using Maglobe.Web.Controllers.Entities.Blogs.Detail;
using Maglobe.Web.Controllers.Entities.Blogs.Edit;
using Maglobe.Web.Controllers.Entities.Blogs.Get;
using Maglobe.Web.Controllers.Entities.Certificates.Add;
using Maglobe.Web.Controllers.Entities.Certificates.Detail;
using Maglobe.Web.Controllers.Entities.Certificates.Edit;
using Maglobe.Web.Controllers.Entities.Certificates.Get;
using Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Add;
using Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Detail;
using Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Edit;
using Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Get;
using Maglobe.Web.Controllers.Entities.Menus.Add;
using Maglobe.Web.Controllers.Entities.Menus.Detail;
using Maglobe.Web.Controllers.Entities.Menus.Edit;
using Maglobe.Web.Controllers.Entities.Menus.Get;
using Maglobe.Web.Controllers.Entities.Pages.Add;
using Maglobe.Web.Controllers.Entities.Pages.Detail;
using Maglobe.Web.Controllers.Entities.Pages.Edit;
using Maglobe.Web.Controllers.Entities.Pages.Get;
using Maglobe.Web.Controllers.Entities.Products.Add;
using Maglobe.Web.Controllers.Entities.Products.Detail;
using Maglobe.Web.Controllers.Entities.Products.Edit;
using Maglobe.Web.Controllers.Entities.Products.Get;
using Maglobe.Web.Controllers.Entities.Settings.Add;
using Maglobe.Web.Controllers.Entities.Settings.Detail;
using Maglobe.Web.Controllers.Entities.Settings.Edit;
using Maglobe.Web.Controllers.Entities.Settings.Get;
using Maglobe.Web.Controllers.Entities.Testimonials.Add;
using Maglobe.Web.Controllers.Entities.Testimonials.Detail;
using Maglobe.Web.Controllers.Entities.Testimonials.Edit;
using Maglobe.Web.Controllers.Entities.Testimonials.Get;
using Maglobe.Web.Controllers.Entities.Users.Add;
using Maglobe.Web.Controllers.Entities.Users.Detail;
using Maglobe.Web.Controllers.Entities.Users.Edit;
using Maglobe.Web.Controllers.Entities.Users.Get;
using Maglobe.Web.Extensions;

namespace Maglobe.Web.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region User

            CreateMap<RegisterRequest, User>()
                .ForMember(w => w.Password, opt => opt.Ignore())
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<UserAddRequest, User>()
                .ForMember(w => w.Password, opt => opt.Ignore())
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.IsActive, opt => opt.MapFrom(e => true));

            CreateMap<UserEditRequest, User>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.Password, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<User, UserDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.Password, opt => opt.Ignore())
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.LastLoginAt,
                    opt => opt.MapFrom(e =>
                        e.LastLoginAt.HasValue ? e.LastLoginAt.Value.ToPersianDateTime() : String.Empty));

            CreateMap<User, UserGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.LastLoginAt,
                    opt => opt.MapFrom(e =>
                        e.LastLoginAt.HasValue ? e.LastLoginAt.Value.ToPersianDateTime() : String.Empty));

            #endregion
            
            #region Menu

            CreateMap<MenuAddRequest, Menu>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<MenuEditRequest, Menu>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<Menu, MenuDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            CreateMap<Menu, MenuGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
            #region Certificate

            CreateMap<CertificateAddRequest, Certificate>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<CertificateEditRequest, Certificate>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<Certificate, CertificateDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.Picture, opt =>
                    opt.MapFrom(e =>
                        e.AttachmentId.HasValue
                            ? String.Join("", e.Attachment.Image.Select(Convert.ToChar))
                            : String.Empty));

            CreateMap<Certificate, CertificateGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
            #region Testimonial

            CreateMap<TestimonialAddRequest, Testimonial>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<TestimonialEditRequest, Testimonial>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<Testimonial, TestimonialDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.Picture, opt =>
                    opt.MapFrom(e =>
                        e.AttachmentId.HasValue
                            ? String.Join("", e.Attachment.Image.Select(Convert.ToChar))
                            : String.Empty));

            CreateMap<Testimonial, TestimonialGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
            #region Setting

            CreateMap<SettingAddRequest, Setting>()
                .ForMember(w => w.WebsiteLogo, opt => opt.Ignore());

            CreateMap<SettingEditRequest, Setting>()
                .ForMember(w => w.Id, opt => opt.Ignore());

            CreateMap<Setting, SettingDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.WebsiteLogoImage, opt =>
                    opt.MapFrom(e =>
                         String.Join("", e.WebsiteLogo.Image.Select(Convert.ToChar))));

            CreateMap<Setting, SettingGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id));

            #endregion
            
            #region Product

            CreateMap<ProductAddRequest, Product>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<ProductEditRequest, Product>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<Product, ProductDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.CertificateItems, opt =>
                    opt.MapFrom(e =>
                        e.ProductCertificates.Any()
                            ? e.ProductCertificates.Select(w => new CertificateItem()
                            {
                                Key = w.CertificateId,
                                //Image = w.Certificate.Attachment != null ? String.Join("", w.Certificate.Attachment.Image.Select(Convert.ToChar)) : string.Empty,
                                Title = w.Certificate.Title
                            })
                            : null));

            CreateMap<Product, ProductGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
            #region DynamicPage

            CreateMap<DynamicPageAddRequest, DynamicPage>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<DynamicPageEditRequest, DynamicPage>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<DynamicPage, DynamicPageDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            CreateMap<DynamicPage, DynamicPageGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
            #region CustomerSupportRequest

            CreateMap<CustomerSupportRequestAddRequest, CustomerSupportRequest>()
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<CustomerSupportRequestEditRequest, CustomerSupportRequest>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

            CreateMap<CustomerSupportRequest, CustomerSupportRequestDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            CreateMap<CustomerSupportRequest, CustomerSupportRequestGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
            
                #region Blog

                    CreateMap<BlogAddRequest, Blog>()
                .ForMember(w => w.PublishedDate, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => DateTime.Now))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

                    CreateMap<BlogEditRequest, Blog>()
                .ForMember(w => w.Id, opt => opt.Ignore())
                .ForMember(w => w.PublishedDate, opt => opt.Ignore())
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => DateTime.Now));

                    CreateMap<Blog, BlogDetailResponse>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()))
                .ForMember(w => w.PublishedDate, opt => opt.MapFrom(e => e.PublishedDate.ToPersianDateTime()))
                .ForMember(w => w.Picture, opt =>
                    opt.MapFrom(e =>
                        e.AttachmentId.HasValue
                            ? String.Join("", e.Attachment.Image.Select(Convert.ToChar))
                            : String.Empty));

                    CreateMap<Blog, BlogGetResponseItem>()
                .ForMember(w => w.Key, opt => opt.MapFrom(e => e.Id))
                .ForMember(w => w.PublishedDate, opt => opt.MapFrom(e => e.PublishedDate.ToPersianDateTime()))
                .ForMember(w => w.CreatedAt, opt => opt.MapFrom(e => e.CreatedAt.ToPersianDateTime()))
                .ForMember(w => w.ModifiedAt, opt => opt.MapFrom(e => e.ModifiedAt.ToPersianDateTime()));

            #endregion
        }
    }
}