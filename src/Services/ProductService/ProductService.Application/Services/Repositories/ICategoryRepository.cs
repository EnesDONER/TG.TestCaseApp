
using Core.Persistence.Repositories;
using ProductService.Domain;


namespace ProductService.Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category, Guid>
{

}