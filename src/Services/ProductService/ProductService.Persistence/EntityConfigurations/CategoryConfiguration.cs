using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_Name").IsUnique();

        builder.HasMany(b => b.Products);

        builder.HasData(_seeds);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
    public static Guid CategoryComputerId { get; } = Guid.NewGuid();
    public static Guid CategoryPhoneId { get; } = Guid.NewGuid();
    private IEnumerable<Category> _seeds
    {
        get
        {
            List<Category> categories = new()
            {
                new Category(CategoryComputerId, "Computer"),
                new Category(CategoryPhoneId, "Phone")
            };

            return categories;
        }
    }
}