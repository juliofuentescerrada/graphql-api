using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Model;
using Catalog.Application.Requests.Products;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Products
{
    public class GetProductListHandler : IRequestHandler<GetProductList, IEnumerable<Product>>
    {
        private readonly IDbConnection _db;

        public GetProductListHandler(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Product>> Handle(GetProductList request, CancellationToken cancellationToken)
        {
            return await _db.QueryAsync<Product>("SELECT P.Id, P.Name, B.Name AS BrandName FROM Products P JOIN Brands B ON P.BrandId = B.Id");
        }
    }}