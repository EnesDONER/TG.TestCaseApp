using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using ProductService.Application.Services.Repositories;

namespace ProductService.Application.Features.Products.Queries.GetByCategoryId;

public class GetListByCategoryIdQuery : IRequest<GetListResponse<GetListByCategoryIdResponse>>
{
    public Guid CategoryId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetByCategoryIdProductQueryHandler : IRequestHandler<GetListByCategoryIdQuery, GetListResponse<GetListByCategoryIdResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByCategoryIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByCategoryIdResponse>> Handle(GetListByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync(
                   predicate: p => p.CategoryId == request.CategoryId,
                   index: request.PageRequest.PageIndex,
                   size: request.PageRequest.PageSize,
                   cancellationToken: cancellationToken
               );

            return _mapper.Map<GetListResponse<GetListByCategoryIdResponse>>( products ); 
        }
    }
}
