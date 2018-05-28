using System.Linq;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductComments : IRequest<ILookup<int, Comment>>
    {
        public int[] ProductIds { get; set; }
    }
}