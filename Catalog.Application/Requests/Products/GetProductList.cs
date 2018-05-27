using System.Collections.Generic;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductList : IRequest<IEnumerable<Product>>
    {
    }
}