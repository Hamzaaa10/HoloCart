using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.ImplemintationRepository;
using Microsoft.Extensions.DependencyInjection;

namespace HoloCart.Infrastructure
{
    public static class ModuleInfrasractureDebendancies
    {
        public static IServiceCollection AddInfrasractureDebendancies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IFavouritRepository, FavouritRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepositry, CartItemRepositry>();





            return services;
        }

    }
}
