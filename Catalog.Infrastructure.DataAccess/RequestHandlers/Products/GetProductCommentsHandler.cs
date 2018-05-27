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
    public class GetProductCommentsHandler : IRequestHandler<GetProductComments, IEnumerable<Comment>>
    {
        private readonly IDbConnection _db;

        public GetProductCommentsHandler(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Comment>> Handle(GetProductComments request, CancellationToken cancellationToken)
        {
            return await _db.QueryAsync<Comment>("SELECT Text, Author, CreatedAt FROM Comments WHERE ProductId = @ProductId", new { request.ProductId });
        }
    }
}