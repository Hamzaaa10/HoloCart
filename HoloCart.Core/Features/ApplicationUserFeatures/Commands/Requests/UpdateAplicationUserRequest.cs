using HoloCart.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests
{
    public class UpdateAplicationUserRequest : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public IFormFile? ProfileImage { get; set; }


    }
}
