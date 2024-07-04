using Core.Persistence.Repositories;
using ProductService.Application.Services.Repositories;
using ProductService.Domain;
using ProductService.Persistence.Contexts;

namespace ProductService.Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, Guid, BaseDbContext>, ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}