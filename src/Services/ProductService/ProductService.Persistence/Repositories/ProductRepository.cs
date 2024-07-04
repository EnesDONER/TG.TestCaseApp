using Core.Persistence.Repositories;
using ProductService.Application.Services.Repositories;
using ProductService.Domain;
using ProductService.Persistence.Contexts;

namespace ProductService.Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, Guid, BaseDbContext>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }
}