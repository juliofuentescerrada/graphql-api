using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Brands;
using Catalog.Application.Responses;
using Dapper;
using MediatR;

namespace Catalog.Infrastructure.DataAccess.RequestHandlers.Brands
{
    public class GetBrandListHandler : IRequestHandler<GetBrandList, IEnumerable<Brand>>
    {
        private readonly IDbConnection _db;

        public GetBrandListHandler(IDbConnection db) => _db = db;

        public async Task<IEnumerable<Brand>> Handle(GetBrandList request, CancellationToken cancellationToken)
        {
            return await _db.QueryAsync<Brand>("SELECT Id, Name FROM Brands");
        }
    }
}