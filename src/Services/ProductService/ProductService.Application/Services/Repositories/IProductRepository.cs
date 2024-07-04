
using Core.Persistence.Repositories;
using ProductService.Domain;


namespace ProductService.Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, Guid>
{

}
