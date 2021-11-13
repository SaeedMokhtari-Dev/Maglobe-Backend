namespace Maglobe.Core.Constants
{
    public static class ApiMessages
    {
        public const string ResourceNotFound = "Api.Resource.Not.Found";
        public const string InvalidRequest = "Api.Invalid.Request";
        public const string GenericError = "Api.Generic.Error";
        public const string Forbidden = "Api.Forbidden";
        public const string PageSize = "Api.PageSize";
        public const string PageIndex = "Api.PageIndex";
        public const string DuplicateUserName = "Api.Username.Duplicate";
        public const string DuplicateNationalId = "Api.NationalId.Duplicate";
        public const string DuplicateBarcode = "Api.Barcode.Duplicate";
        public const string DuplicateEmail = "Api.Email.Duplicate";
        public const string NotEnoughBalance = "Api.NotEnoughBalance";
        public const string MinPasswordLengthError = "Api.MinPasswordLengthError";
        public const string IdRequired = "Api.Validate.IdRequired";

        public static class Auth
        {
            public const string EmailRequired = "Api.Auth.Email.Required";
            public const string UsernameRequired = "Api.Auth.Username.Required";
            public const string PasswordRequired = "Api.Auth.Password.Required";
            public const string RoleTypeRequired = "Api.Auth.RoleType.Required";
            public const string TokenRequired = "Api.Auth.Token.Required";
            public const string CurrentPasswordRequired = "Api.Auth.CurrentPassword.Required";
            public const string InvalidCredentials = "Api.Auth.Invalid.Credentials";
            public const string ResetPasswordResponse = "Api.Auth.ResetPassword.Response";
            
            public const string ValidateResetPasswordTokenInvalidToken = "Api.Auth.ValidateResetPasswordToken.InvalidToken";
            public const string ValidateResetPasswordTokenValidToken = "Api.Auth.ValidateResetPasswordToken.ValidToken";
            
            public const string ChangePasswordNotEqualsPasswords = "Api.Auth.ChangePassword.NotEqualPasswords";
            public const string ChangePasswordCurrentPasswordIsNotCorrect = "Api.Auth.ChangePassword.CurrentIsNotCorrect";
            public const string ChangePasswordSuccessful = "Api.Auth.ChangePassword.Successful";

            public const string MinPasswordLengthError = "Api.Auth.MinPasswordLengthError";
        }
        public static class UserMessage
        {
            public const string UserIdRequired = "Api.User.UserId.Required";
            public const string FirstNameRequired = "Api.User.FirstName.Required";    
            public const string LastNameRequired = "Api.User.LastName.Required";    
            public const string EmailRequired = "Api.User.Email.Required";    
            public const string FaxRequired = "Api.User.Fax.Required";    
            public const string BarcodeRequired = "Api.User.Barcode.Required";    
            public const string MinPasswordLengthError = "Api.User.Password.MinPasswordLengthError";
            
            public const string RegisteredSuccessfully = "Api.User.Register.Successful";
            public const string AddedSuccessfully = "Api.User.Add.Successful";
            public const string EditedSuccessfully = "Api.User.Edit.Successful";
            public const string ArchivedSuccessfully = "Api.User.Archived.Successful";
            public const string ActivatedSuccessfully = "Api.User.Activated.Successful";
            public const string PresentedSuccessfully = "Api.User.Presented.Successful";
            public const string DeletedSuccessfully = "Api.User.Deleted.Successful";
            
            public const string UserNotFound = "Api.User.NotFound";
            public const string UserWasPresentedBefore = "Api.User.PresentedBefore";
        }
        public static class MenuMessage
        {
            public const string MenuIdRequired = "Api.Menu.MenuId.Required";
            
            public const string AddedSuccessfully = "Api.Menu.Add.Successful";
            public const string EditedSuccessfully = "Api.Menu.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Menu.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Menu.Deleted.Successful";
            
            public const string MenuNotFound = "Api.Menu.NotFound";
        }
        public static class TestimonialMessage
        {
            public const string TestimonialIdRequired = "Api.Testimonial.TestimonialId.Required";
            
            public const string AddedSuccessfully = "Api.Testimonial.Add.Successful";
            public const string EditedSuccessfully = "Api.Testimonial.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Testimonial.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Testimonial.Deleted.Successful";
            
            public const string TestimonialNotFound = "Api.Testimonial.NotFound";
        }
        public static class CertificateMessage
        {
            public const string CertificateIdRequired = "Api.Certificate.CertificateId.Required";
            
            public const string AddedSuccessfully = "Api.Certificate.Add.Successful";
            public const string EditedSuccessfully = "Api.Certificate.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Certificate.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Certificate.Deleted.Successful";
            
            public const string CertificateNotFound = "Api.Certificate.NotFound";
        }
        public static class SettingMessage
        {
            public const string SettingIdRequired = "Api.Setting.SettingId.Required";
            
            public const string AddedSuccessfully = "Api.Setting.Add.Successful";
            public const string EditedSuccessfully = "Api.Setting.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Setting.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Setting.Deleted.Successful";
            
            public const string SettingNotFound = "Api.Setting.NotFound";
        }
        public static class ProductMessage
        {
            public const string ProductIdRequired = "Api.Product.ProductId.Required";
            
            public const string AddedSuccessfully = "Api.Product.Add.Successful";
            public const string EditedSuccessfully = "Api.Product.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Product.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Product.Deleted.Successful";
            
            public const string ProductNotFound = "Api.Product.NotFound";
        }
        public static class PageMessage
        {
            public const string PageIdRequired = "Api.Page.PageId.Required";
            
            public const string AddedSuccessfully = "Api.Page.Add.Successful";
            public const string EditedSuccessfully = "Api.Page.Edit.Successful";
            public const string ActivatedSuccessfully = "Api.Page.Activated.Successful";
            public const string DeletedSuccessfully = "Api.Page.Deleted.Successful";
            
            public const string PageNotFound = "Api.Page.NotFound";
        }
        public static class CustomerSupportRequestMessage
        {
            public const string CustomerSupportRequestIdRequired = "Api.CustomerSupportRequest.CustomerSupportRequestId.Required";
            
            public const string AddedSuccessfully = "Api.CustomerSupportRequest.Add.Successful";
            public const string EditedSuccessfully = "Api.CustomerSupportRequest.Edit.Successful";
            public const string DeletedSuccessfully = "Api.CustomerSupportRequest.Deleted.Successful";
            
            public const string CustomerSupportRequestNotFound = "Api.CustomerSupportRequest.NotFound";
        }
    }
}
