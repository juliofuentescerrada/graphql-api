using System;
using Catalog.Domain.Model;
using Catalog.Infrastructure.DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.DataAccess
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }

        public CatalogDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
