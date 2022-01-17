using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.ProductName)
                .HasColumnName("name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.ProductCode)
                .HasColumnName("product_code")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(45);

            builder.Property(x => x.Category)
               .HasColumnName("category")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(45);

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasColumnType("FLOAT")
                .HasPrecision(2);

            builder.Property(x => x.PromocionalPrice)
                .HasColumnName("promocional_price")
                .HasColumnType("FLOAT")
                .HasPrecision(2);

            builder.Property(x => x.Image)
                .HasColumnName("image")
                .HasColumnType("TEXT")
               .HasMaxLength(1200);

        }
    }
}
