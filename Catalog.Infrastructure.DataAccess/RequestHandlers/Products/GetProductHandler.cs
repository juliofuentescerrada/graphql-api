using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Model;
using Catalog.Application.Requests.Products;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Products
{
    public class GetProductHandler : IRequestHandler<GetProduct, Product>
    {
        private readonly IDbConnection _db;

        public GetProductHandler(IDbConnection db) => _db = db;

        public async Task<Product> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            return await _db.QuerySingleOrDefaultAsync<Product>(
                @"SELECT P.Id, P.Name, B.Name AS BrandName 
                  FROM Products P JOIN Brands B ON P.BrandId = B.Id
                  WHERE P.Id = @Id", new { request.Id });
        }
    }
}