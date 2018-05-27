using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Brands;
using Catalog.Application.Responses;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Brands
{
    public class GetBrandHandler : IRequestHandler<GetBrand, Brand>
    {
        private readonly IDbConnection _db;

        public GetBrandHandler(IDbConnection db) => _db = db;

        public async Task<Brand> Handle(GetBrand request, CancellationToken cancellationToken)
        {
            return await _db.QuerySingleOrDefaultAsync<Brand>("SELECT Id, Name FROM Brands WHERE Id = @Id", new { request.Id });
        }
    }
}