using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductFeatures.Query.Requests;
using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using HoloCart.Core.Wrappers;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Query.Hundller
{
    public class ProductHundller : ResponseHandller,
                                   IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>,
                                   IRequestHandler<GetProductListPagintionQuery, PaginatedResult<GetProductListPagintionResponse>>,
                                   IRequestHandler<GetProductsByCategoryQuery, PaginatedResult<GetProductsByCategoryResponse>>,
                                   IRequestHandler<GetAllProductsWithDiscountQuery, PaginatedResult<GetAllProductsWithDiscountResponse>>


    {



        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IFavouritService _favouritService;

        public ProductHundller(IMapper mapper, IProductService productService, IFavouritService favouritService)
        {
            _mapper = mapper;
            _productService = productService;
            _favouritService = favouritService;
        }
        public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdIncluded(request.ProductId);
            if (product == null) return NotFound<GetProductByIdResponse>();
            var result = _mapper.Map<GetProductByIdResponse>(product);
            var userFavoriteProductIds = await _favouritService.GetUserFavoriteProductIdsAsync(request.UserId);

            var favoriteProductIdsSet = new HashSet<int>(userFavoriteProductIds);


            result.IsFavorite = favoriteProductIdsSet.Contains(request.ProductId);

            return Success(result);

        }

        public async Task<PaginatedResult<GetProductsByCategoryResponse>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = _productService.GetProductsByCategoryQuarable(request.CategoryId, request.SearchBy, request.OrderBy).AsQueryable();
            var paginatedProducts = await _mapper.ProjectTo<GetProductsByCategoryResponse>(products)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            var userFavoriteProductIds = await _favouritService.GetUserFavoriteProductIdsAsync(request.ApplicationUserId);

            var favoriteProductIdsSet = new HashSet<int>(userFavoriteProductIds);

            foreach (var item in paginatedProducts.Data)
            {
                item.IsFavorite = favoriteProductIdsSet.Contains(item.ProductId);
            }
            return paginatedProducts;
        }

        public async Task<PaginatedResult<GetAllProductsWithDiscountResponse>> Handle(GetAllProductsWithDiscountQuery request, CancellationToken cancellationToken)
        {
            var products = _productService.GetProductsByDiscountQuarable(request.DiscountPercentage, request.SearchBy).AsQueryable();
            var paginatedProducts = await _mapper.ProjectTo<GetAllProductsWithDiscountResponse>(products)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var userFavoriteProductIds = await _favouritService.GetUserFavoriteProductIdsAsync(request.ApplicationUserId);

            var favoriteProductIdsSet = new HashSet<int>(userFavoriteProductIds);

            foreach (var item in paginatedProducts.Data)
            {
                item.IsFavorite = favoriteProductIdsSet.Contains(item.ProductId);
            }

            return paginatedProducts;
        }

        async Task<PaginatedResult<GetProductListPagintionResponse>> IRequestHandler<GetProductListPagintionQuery, PaginatedResult<GetProductListPagintionResponse>>.Handle(GetProductListPagintionQuery request, CancellationToken cancellationToken)
        {
            var products = _productService.GetProductsQuarable(request.SearchBy, request.OrderBy).AsQueryable();
            var paginatedProducts = await _mapper.ProjectTo<GetProductListPagintionResponse>(products)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            var userFavoriteProductIds = await _favouritService.GetUserFavoriteProductIdsAsync(request.ApplicationUserId);

            var favoriteProductIdsSet = new HashSet<int>(userFavoriteProductIds);

            foreach (var item in paginatedProducts.Data)
            {
                item.IsFavorite = favoriteProductIdsSet.Contains(item.ProductId);
            }
            return paginatedProducts;
        }
    }
}
