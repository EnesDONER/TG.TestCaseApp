using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using ProductService.Application.Features.Categories.Queries.GetList;
using ProductService.Domain;

namespace ProductService.Application.Features.Categories.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, GetListCategoryListItemDto>().ReverseMap();
        CreateMap<Paginate<Category>, GetListResponse<GetListCategoryListItemDto>>().ReverseMap();
    }
}