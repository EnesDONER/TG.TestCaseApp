using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using ProductService.Application.Services.Repositories;

namespace ProductService.Application.Features.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<GetListResponse<GetListProductListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, GetListResponse<GetListProductListItemDto>>
        {

            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListProductListItemDto>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetListAsync(
                  index: request.PageRequest.PageIndex,
                  size: request.PageRequest.PageSize,
                  cancellationToken: cancellationToken
                );

                return _mapper.Map<GetListResponse<GetListProductListItemDto>>( products );
            }
        }
    }
}
