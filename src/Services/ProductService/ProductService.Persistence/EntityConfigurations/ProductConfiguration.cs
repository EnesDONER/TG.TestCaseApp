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
        builder.Property(b => b.Image).HasColumnName("Image").IsRequired();
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
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "LENOVO AIO 3 INTEL CORE İ5 12450H 3.3 GHZ 8 GB 512 GB","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/acer/thumb/142883-4_small.jpg",16000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "EXPER XERA XC136 INTEL CORE İ5 13400F 2.5GHZ 16GB","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/grundig/thumb/0001-layer-3_small.jpg",15000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "HP 898B7EA INTEL CORE İ5 1335U 3.4 GHZ 8 GB 512 GB","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/hp/thumb/146251-1_small.jpg",16500),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "EXPER DIAMOND DEX600 INTEL CORE İ5 11400 2.6GHZ 8GB 256GB SSD INTEL UHD730","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/philips/thumb/140996-1_large.jpg",35000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryComputerId, "CASPER Excalibur E650 İ5 12400F 2.5GHZ 32GB 500GB","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/exper/thumb/144179-1_large.jpg",15400),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "iPhone 13 128 Gb Akıllı Telefon Mavi","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129895-1_large.jpg",25000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "iPhone 13 128 Gb Akıllı Telefon Yıldız Işığı","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129885-1_large.jpg",12000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "Samsung Galaxy A15 6/128 Gb Akıllı Telefon Siyah","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/129743-1_large.jpg",35000),
                new Product(Guid.NewGuid(),CategoryConfiguration.CategoryPhoneId, "Xiaomi Redmi 12 8/128 GB Gece Yarısı Siyahı Akıllı Telefon","https://cdn.vatanbilgisayar.com/Upload/PRODUCT/tcl/thumb/142148-1_large.jpg",25400)
            };

            return products;
        }
    }
}
