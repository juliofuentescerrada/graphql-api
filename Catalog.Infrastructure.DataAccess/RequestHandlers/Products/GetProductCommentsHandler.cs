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
    public class GetProductCommentsHandler : IRequestHandler<GetProductComments, ILookup<int,Comment>>
    {
        private readonly IDbConnection _db;

        public GetProductCommentsHandler(IDbConnection db) => _db = db;

        public async Task<ILookup<int, Comment>> Handle(GetProductComments request, CancellationToken cancellationToken)
        {
            var comments = await _db.QueryAsync<Comment>("SELECT ProductId, Text, Author, CreatedAt FROM Comments WHERE ProductId IN @ProductIds", new { request.ProductIds });

            return comments.ToLookup(e => e.ProductId);
        }
    }
}