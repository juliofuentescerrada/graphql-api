using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Products;
using Catalog.Application.Responses;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Products
{
    public class GetProductImagesHandler : IRequestHandler<GetProductImages, IEnumerable<Image>>
    {
        private readonly IDbConnection _db;

        public GetProductImagesHandler(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Image>> Handle(GetProductImages request, CancellationToken cancellationToken)
        {
            return await _db.QueryAsync<Image>("SELECT Url FROM Images WHERE ProductId = @ProductId", new { request.ProductId });
        }
    }
}