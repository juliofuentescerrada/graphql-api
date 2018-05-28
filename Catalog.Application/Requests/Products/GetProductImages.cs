using System.Linq;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductImages : IRequest<ILookup<int, Image>>
    {
        public int[] ProductIds { get; set; }
    }
}