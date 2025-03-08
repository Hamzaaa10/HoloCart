using HoloCart.Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests
{
    public class ChangePasswordRequest : IRequest<Response<string>>
    {
        public int Id { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
