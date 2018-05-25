using System.Collections.Generic;
using Catalog.Application.Model;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductImages : IRequest<IEnumerable<Image>>
    {
        public int ProductId { get; set; }
    }
}