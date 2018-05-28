using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Brands;
using Catalog.Application.Responses;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Brands
{
    public class GetBrandProductsHandler : IRequestHandler<GetBrandProducts, ILookup<int, Product>>
    {
        private readonly IDbConnection _db;

        public GetBrandProductsHandler(IDbConnection db) => _db = db;

        public async Task<ILookup<int, Product>> Handle(GetBrandProducts request, CancellationToken cancellationToken)
        {
            var products = await _db.QueryAsync<Product>(
                @"SELECT P.Id, P.Name, B.Name AS BrandName, B.Id AS BrandId
                FROM Products P JOIN Brands B ON P.BrandId = B.Id
                WHERE B.Id IN @BrandIds", new { request.BrandIds });

            return products.ToLookup(e => e.BrandId);

        }
    }
}