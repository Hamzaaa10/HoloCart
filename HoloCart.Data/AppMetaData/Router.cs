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
            public const string FacebookLogin = Prefix + "/FacebookLogin";
            public const string GoogleLogin = Prefix + "/GoogleLogin";

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
        public static class CategoryRouting
        {
            public const string Prefix = Rule + "Category";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById" + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + "/{id}";
        }
        public static class DiscountRouting
        {
            public const string Prefix = Rule + "Discount";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById" + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Update";
            public const string Delete = Prefix + "/Delete" + "/{id}";
        }
        public static class FavouritRouting
        {
            public const string Prefix = Rule + "Favourit";
            public const string GetAll = Prefix + "/user" + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
        }
        public static class ProductRouting
        {
            public const string Prefix = Rule + "Product";
            public const string GetAll = Prefix + "/Paganited";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete";
            public const string Update = Prefix + "/Update";
            public const string GetById = Prefix + "/GetById" + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
            public const string ProductsByCategory = Prefix + "/ProductsByCategory";
            public const string PaginatedByDiscount = Prefix + "/ProductsByDiscount";

        }
        public static class ReviewRouting
        {
            public const string Prefix = Rule + "Review";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update" + "/{id}";
            public const string ReviewsWithProduct = Prefix + "/Product" + "/{id}";
        }
        public static class ShippingAddressRouting
        {
            public const string Prefix = Rule + "ShippingAddress";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById" + "/{id}";
        }

        public static class PaymentRouting
        {
            public const string Prefix = Rule + "Payments";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById" + "/{id}";
        }
        public static class OrderItemRouting
        {
            public const string Prefix = Rule + "OrderItem";
            public const string Create = Prefix + "/Create";

        }
        public static class CartRouting
        {
            public const string Prefix = Rule + "Cart";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetByUserId = Prefix + "/User" + "/{id}";
            public const string ApplayCode = Prefix + "/ApplayCuponCode";

        }
        public static class CartItemRouting
        {
            public const string Prefix = Rule + "CartItem";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/GetById" + "/{id}";
        }

        public static class ProductColorRouting
        {
            public const string Prefix = Rule + "ProductColor";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string GetAll = Prefix + "/ProductId";
            public const string GetById = Prefix + "/{id}";
        }

        public static class ProductImageRouting
        {
            public const string Prefix = Rule + "ProductImage";
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Update = Prefix + "/Update";
            public const string GetAll = Prefix + "/GetAll";
            public const string GetById = Prefix + "/{id}";
        }
    }
}