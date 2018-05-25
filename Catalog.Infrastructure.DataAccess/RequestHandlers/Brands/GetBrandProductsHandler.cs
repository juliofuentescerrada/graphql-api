using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Model;
using Catalog.Application.Requests.Brands;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Brands
{
    public class GetBrandProductsHandler : IRequestHandler<GetBrandProducts, IEnumerable<Product>>
    {
        private readonly IDbConnection _db;

        public GetBrandProductsHandler(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Product>> Handle(GetBrandProducts request, CancellationToken cancellationToken)
        {
            return await _db.QueryAsync<Product>(
                @"SELECT P.Id, P.Name, B.Name AS BrandName 
                FROM Products P JOIN Brands B ON P.BrandId = B.Id
                WHERE B.Id = @BrandId", new { request.BrandId });
        }
    }
}