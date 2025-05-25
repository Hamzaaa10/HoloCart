using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IShippingAddressService
    {
        public Task<string> AddShippingAddressAsync(ShippingAddress shippingAddress);
        public Task<string> UpdateShippingAddressAsync(ShippingAddress shippingAddress);
        public Task<string> DeleteShippingAddressAsync(int id);
        public Task<ShippingAddress> GetShippingAddressById(int id);
        public Task<List<ShippingAddress>> GetAllShippingAddressAcync();
        public Task<List<ShippingAddress>> GetShippingAddressesByUserId(int userId);

    }
}
