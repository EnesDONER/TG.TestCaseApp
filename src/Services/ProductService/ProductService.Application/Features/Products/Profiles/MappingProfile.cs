using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using ProductService.Application.Features.Products.Queries.GetByCategoryId;
using ProductService.Application.Features.Products.Queries.GetList;
using ProductService.Domain;

namespace ProductService.Application.Features.Products.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, GetListProductListItemDto>().ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListProductListItemDto>>().ReverseMap();

        CreateMap<Product, GetListByCategoryIdResponse>().ReverseMap();
        CreateMap<Paginate<Product>, GetListResponse<GetListByCategoryIdResponse>>().ReverseMap();
    }
}
