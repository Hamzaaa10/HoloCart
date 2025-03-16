using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.FavouriteFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.FavouriteFeatures.Command.Hundller
{
    public class FavouriteHundller : ResponseHandller,
                                     IRequestHandler<AddToFavouritesCommand, Response<string>>,
                                     IRequestHandler<RemoveFavouriteCommand, Response<string>>

    {
        private readonly IFavouritService _favouritService;
        private readonly IMapper _mapper;

        public FavouriteHundller(IFavouritService favouritService, IMapper mapper)
        {
            _favouritService = favouritService;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddToFavouritesCommand request, CancellationToken cancellationToken)
        {
            var MappedFavourit = _mapper.Map<Favourite>(request);
            var result = await _favouritService.AddToFavouritesAsync(MappedFavourit);
            if (result == "Success") return Success<string>(result);
            else if (result == "FailedInAdd") return BadRequest<string>();
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(RemoveFavouriteCommand request, CancellationToken cancellationToken)
        {
            var result = await _favouritService.DeleteFavouritesAsync(request.ProductId, request.UserId);
            switch (result)
            {
                case "NotInFavourit": return NotFound<string>(" Not Found In Favourit For this user ");
                case "FailedInDeleted": return BadRequest<string>("FailedInDeleted");
                case "Success": return Success<string>("Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
