using Microsoft.EntityFrameworkCore;
using ProductService.Domain;

namespace ProductService.Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Price).HasColumnName("Price").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Product_Name").IsUnique();

        builder.HasOne(b => b.Category);

        builder.HasData(_seeds);

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
    private IEnumerable<Product> _seeds
    {
        get
        {
            List<Product> products = new()
            {
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "LENOVO AIO 3 INTEL CORE İ5 12450H 3.3 GHZ 8 GB 512 GB",16000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "EXPER XERA XC136 INTEL CORE İ5 13400F 2.5GHZ 16GB",15000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "HP 898B7EA INTEL CORE İ5 1335U 3.4 GHZ 8 GB 512 GB",16500),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "EXPER DIAMOND DEX600 INTEL CORE İ5 11400 2.6GHZ 8GB 256GB SSD INTEL UHD730",35000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "CASPER Excalibur E650 İ5 12400F 2.5GHZ 32GB 500GB",15400),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "iPhone 13 128 Gb Akıllı Telefon Mavi",25000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "iPhone 13 128 Gb Akıllı Telefon Yıldız Işığı",12000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "Samsung Galaxy A15 6/128 Gb Akıllı Telefon Siyah",35000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "Xiaomi Redmi 12 8/128 GB Gece Yarısı Siyahı Akıllı Telefon",25400)
            };

            return products;
        }
    }
}
