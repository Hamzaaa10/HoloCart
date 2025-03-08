using HoloCart.Data.Entities.Identity;

namespace HoloCart.Data.Entities
{
    public class ShippingAddress
    {
        public int ShippingAddressId { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }

}