using System.Threading;
using System.Threading.Tasks;
using Catalog.Domain.Model;

namespace Catalog.Domain.Services.Products
{
    public interface IProductsRepository
    {
        Task<Product> Find(int id, CancellationToken cancellationToken);

        Task Save(Product product, CancellationToken cancellationToken);
    }
}
