using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using ProductService.Application.Services.Repositories;

namespace ProductService.Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryListItemDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetListAsync(
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken
            );

            return _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(categories);
        }
    }
}
