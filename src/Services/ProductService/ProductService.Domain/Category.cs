using Core.Persistence.Repositories;

namespace ProductService.Domain;

public class Category : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Product>? Products { get; set; }

    private Category()
    {
        Products = new HashSet<Product>();
    }

    public Category(Guid id, string name):this()
    {
        Id = id;
        Name = name;
    }
}
