using System.Collections.Generic;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Brands
{
    public class GetBrandList : IRequest<IEnumerable<Brand>>
    {
    }
}