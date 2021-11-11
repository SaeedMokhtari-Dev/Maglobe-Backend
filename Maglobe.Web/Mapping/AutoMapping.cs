using System;
using AutoMapper;
using Maglobe.DataAccess.Entities;
using Maglobe.Web.Controllers.Auth.Register;
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
        }
    }
}