using HoloCart.Service.Abstract;
using HoloCart.Service.Implemintation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HoloCart.Service
{
    public static class ModuleServiceDebendancies
    {
        public static IServiceCollection AddServiceDebendancies(this IServiceCollection services)
        {

            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IFavouritService, FavouritService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IShippingAddressService, ShippingAddressService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartItemService, CartItemService>();
            services.AddTransient<IProductColorService, ProductColorService>();
            services.AddTransient<IProductImageService, ProductImageService>();


            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });
            return services;

        }
    }
}
