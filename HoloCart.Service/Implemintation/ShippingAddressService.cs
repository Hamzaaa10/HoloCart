using HoloCart.Data.Entities;
using HoloCart.Data.Entities.Identity;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class ShippingAddressService : IShippingAddressService
    {
        private readonly IShippingAddressRepository _shippingAddressRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public ShippingAddressService(IShippingAddressRepository shippingAddressRepository, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _shippingAddressRepository = shippingAddressRepository;
        }
        public async Task<string> AddShippingAddressAsync(ShippingAddress shippingAddress)
        {
            try
            {
                await _shippingAddressRepository.AddAsync(shippingAddress);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }

        }

        public async Task<string> DeleteShippingAddressAsync(int id)
        {
            var shippingAddress = await _shippingAddressRepository.GetByIdAsync(id);
            if (shippingAddress == null) return "NotFound";

            try
            {
                await _shippingAddressRepository.DeleteAsync(shippingAddress);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }

        public async Task<List<ShippingAddress>> GetAllShippingAddressAcync()
        {
            return await _shippingAddressRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<ShippingAddress> GetShippingAddressById(int id)
        {
            return await _shippingAddressRepository.GetByIdAsync(id);
        }

        public async Task<List<ShippingAddress>> GetShippingAddressesByUserId(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return null;
            return await _shippingAddressRepository.GetTableNoTracking()
                .Where(x => x.ApplicationUserId == userId)
                .ToListAsync();
        }

        public async Task<string> UpdateShippingAddressAsync(ShippingAddress shippingAddress)
        {

            try
            {
                await _shippingAddressRepository.UpdateAsync(shippingAddress);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInUpdate";
            }
        }
    }
}
