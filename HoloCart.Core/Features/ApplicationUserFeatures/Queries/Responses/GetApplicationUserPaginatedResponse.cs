namespace HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses
{
    public class GetApplicationUserPaginatedResponse
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
