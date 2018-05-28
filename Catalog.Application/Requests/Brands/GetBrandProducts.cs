using System.Linq;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Brands
{
    public class GetBrandProducts : IRequest<ILookup<int, Product>>
    {
        public int[] BrandIds { get; set; }
    }
}