using HoloCart.Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests
{
    public class AddAplicationUserRequest : IRequest<Response<string>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string? Address { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
