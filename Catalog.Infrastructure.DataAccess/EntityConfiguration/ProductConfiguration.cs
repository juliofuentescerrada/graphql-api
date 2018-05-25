using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.DataAccess.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Comments).WithOne();
            builder.HasMany(e => e.Images).WithOne();
            builder.HasOne(e => e.Brand).WithMany();

            var images = builder.Metadata.FindNavigation(nameof(Product.Images));
            images.SetPropertyAccessMode(PropertyAccessMode.Field);

            var comments = builder.Metadata.FindNavigation(nameof(Product.Comments));
            comments.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}