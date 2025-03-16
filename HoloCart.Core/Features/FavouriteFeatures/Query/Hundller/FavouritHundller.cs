using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.FavouriteFeatures.Query.Requests;
using HoloCart.Core.Features.FavouriteFeatures.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.FavouriteFeatures.Query.Hundller
{
    public class FavouritHundller : ResponseHandller, IRequestHandler<GetAllFavouritsQuery, Response<List<GetAllFavouritsResponse>>>
    {
        private readonly IFavouritService _favouritService;
        private readonly IMapper _mapper;

        public FavouritHundller(IFavouritService favouritService, IMapper mapper)
        {
            _favouritService = favouritService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetAllFavouritsResponse>>> Handle(GetAllFavouritsQuery request, CancellationToken cancellationToken)
        {
            var FavouritProduct = await _favouritService.GetAllFavouritProducts(request.UserId);
            var result = _mapper.Map<List<GetAllFavouritsResponse>>(FavouritProduct);
            return Success(result);
        }
    }
}
