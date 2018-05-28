using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Products;
using Catalog.Application.Responses;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Products
{
    public class GetProductImagesHandler : IRequestHandler<GetProductImages, ILookup<int, Image>>
    {
        private readonly IDbConnection _db;

        public GetProductImagesHandler(IDbConnection db) => _db = db;

        public async Task<ILookup<int, Image>> Handle(GetProductImages request, CancellationToken cancellationToken)
        {
            var images = await _db.QueryAsync<Image>("SELECT ProductId, Url FROM Images WHERE ProductId IN @ProductIds", new { request.ProductIds });

            return images.ToLookup(e => e.ProductId);
        }
    }
}