namespace HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses
{
    public class GetShippingAddressesByUserIdResponse
    {
        public int ShippingAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
