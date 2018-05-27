using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Model;
using Catalog.Domain.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CatalogDbContext _db;

        public ProductsRepository(CatalogDbContext db)
        {
            _db = db;
        }
        public Task<Product> Find(int id, CancellationToken cancellationToken)
        {
            return _db.Products.FindAsync(new object[] { id }, cancellationToken);
        }

        public Task Save(Product product, CancellationToken cancellationToken)
        {
            if (product.Id == default(int))
            {
                _db.Products.AddAsync(product, cancellationToken);
            }
            else
            {
                _db.Entry(product).State = EntityState.Modified;
            }

            return _db.SaveChangesAsync(cancellationToken);
        }
    }
}