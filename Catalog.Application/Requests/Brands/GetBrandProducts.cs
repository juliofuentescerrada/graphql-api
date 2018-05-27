using System.Collections.Generic;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Brands
{
    public class GetBrandProducts : IRequest<IEnumerable<Product>>
    {
        public int BrandId { get; set; }
    }
}