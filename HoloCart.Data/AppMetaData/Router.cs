namespace HoloCart.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";




        public static class ApplicationUserRouting
        {
            public const string Prefix = Rule + "User";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string ChangePassword = Prefix + "/ChangePassword";
            public const string Paginated = Prefix + "/Paginated";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + "/{id}";
        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Rule + "Authentication";
            public const string Register = Prefix + "/Register";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string ValidateToken = Prefix + "/ValidateToken";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
            public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";
            public const string ResetPassword = Prefix + "/ResetPassword";





        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "Authorization";
            public const string Create = Prefix + "/Role" + "/Create";
            public const string Update = Prefix + "/Role" + "/Update";
            public const string Delete = Prefix + "/Role" + "/Delete" + "/{id}";
            public const string GetAll = Prefix + "/Role" + "/GetAll";
            public const string GetById = Prefix + "/Role" + "/GetById" + "/{id}";
            public const string ManageUserRole = Prefix + "/Role" + "/ManageUserRole" + "/{id}";
            public const string ManageUserClaims = Prefix + "/Claim" + "/ManageUserClaims" + "/{id}";
            public const string UpdateUserRoles = Prefix + "/Role" + "/UpdateUserRoles";
            public const string UpdateUserClaims = Prefix + "/Claim" + "/UpdateUserClaims";
        }
        public static class EmailRouting
        {
            public const string Prefix = Rule + "Email";
            public const string SendEmail = Prefix + "Send";
        }
    }
}
