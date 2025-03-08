using HoloCart.Core.Bases;
using HoloCart.Data.Requests;
using MediatR;

namespace HoloCart.Core.Features.Authorization.Commands.Requests
{
    public class UpdateUserClaimRequest : EditUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
