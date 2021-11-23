namespace Maglobe.Web.Configuration.Constants
{
    public static class Endpoints
    {
        /*Auth APIs*/
        public const string ApiAuthRegister = "/api/auth/register";
        public const string ApiAuthLogin = "/api/auth/login";
        public const string ApiAuthResetPassword = "/api/auth/reset-password";
        public const string ApiAuthValidateResetPasswordToken = "/api/auth/validate-reset-password-token";
        public const string ApiAuthChangePassword = "/api/auth/change-password";
        public const string ApiAuthChangeUserPassword = "/api/auth/change-user-password";
        public const string ApiAuthLogout = "/api/auth/logout";
        public const string ApiAuthCheck = "/api/auth/check";
        public const string ApiAuthRefreshAccessToken = "/api/auth/refresh-access-token";
        public const string ApiUserInfo = "/api/user/info";
        
        /*admin APIs*/

        #region  Users

        public const string ApiUserGet = "/api/user/get";
        public const string ApiUserAdd = "/api/user/add";
        public const string ApiUserEdit = "/api/user/edit";
        public const string ApiUserDetail = "/api/user/detail";
        public const string ApiUserDelete = "/api/user/delete";
        public const string ApiUserList = "/api/user/list";
        public const string ApiUserActive = "/api/user/active";
        public const string ApiUserPresent = "/api/user/present";

        #endregion
        
        #region  Menus

        public const string ApiMenuGet = "/api/menu/get";
        public const string ApiMenuAdd = "/api/menu/add";
        public const string ApiMenuEdit = "/api/menu/edit";
        public const string ApiMenuDetail = "/api/menu/detail";
        public const string ApiMenuDelete = "/api/menu/delete";
        public const string ApiMenuList = "/api/menu/list";
        public const string ApiMenuActive = "/api/menu/active";
        
        #endregion
        
        #region  Testimonials

        public const string ApiTestimonialGet = "/api/testimonial/get";
        public const string ApiTestimonialAdd = "/api/testimonial/add";
        public const string ApiTestimonialEdit = "/api/testimonial/edit";
        public const string ApiTestimonialDetail = "/api/testimonial/detail";
        public const string ApiTestimonialDelete = "/api/testimonial/delete";
        public const string ApiTestimonialList = "/api/testimonial/list";
        public const string ApiTestimonialActive = "/api/testimonial/active";
        
        #endregion
        
        #region  Certificates

        public const string ApiCertificateGet = "/api/certificate/get";
        public const string ApiCertificateAdd = "/api/certificate/add";
        public const string ApiCertificateEdit = "/api/certificate/edit";
        public const string ApiCertificateDetail = "/api/certificate/detail";
        public const string ApiCertificateDelete = "/api/certificate/delete";
        public const string ApiCertificateList = "/api/certificate/list";
        public const string ApiCertificateActive = "/api/certificate/active";
        
        #endregion
        
        #region  Settings

        public const string ApiSettingGet = "/api/setting/get";
        public const string ApiSettingAdd = "/api/setting/add";
        public const string ApiSettingEdit = "/api/setting/edit";
        public const string ApiSettingDetail = "/api/setting/detail";
        public const string ApiSettingDelete = "/api/setting/delete";
        
        #endregion
        
        #region  Products

        public const string ApiProductGet = "/api/product/get";
        public const string ApiProductAdd = "/api/product/add";
        public const string ApiProductEdit = "/api/product/edit";
        public const string ApiProductDetail = "/api/product/detail";
        public const string ApiProductDelete = "/api/product/delete";
        public const string ApiProductList = "/api/product/list";
        public const string ApiProductActive = "/api/product/active";
        
        #endregion
        
        #region  CustomerSupportRequests

        public const string ApiCustomerSupportRequestGet = "/api/customer-support-request/get";
        public const string ApiCustomerSupportRequestAdd = "/api/customer-support-request/add";
        public const string ApiCustomerSupportRequestEdit = "/api/customer-support-request/edit";
        public const string ApiCustomerSupportRequestDetail = "/api/customer-support-request/detail";
        public const string ApiCustomerSupportRequestDelete = "/api/customer-support-request/delete";
        
        #endregion
        
        #region  DynamicPages

        public const string ApiDynamicPageGet = "/api/dynamic-page/get";
        public const string ApiDynamicPageAdd = "/api/dynamic-page/add";
        public const string ApiDynamicPageEdit = "/api/dynamic-page/edit";
        public const string ApiDynamicPageDetail = "/api/dynamic-page/detail";
        public const string ApiDynamicPageDelete = "/api/dynamic-page/delete";
        public const string ApiDynamicPageList = "/api/dynamic-page/list";
        public const string ApiDynamicPageActive = "/api/dynamic-page/active";
        
        #endregion
        
        #region  Attachment

        public const string ApiAttachmentDetail = "/api/attachment/detail";

        #endregion 
        

        public const string ApiLog = "/api/log";
        public const string Swagger = "/swagger/v1/swagger.json";
    }
}
