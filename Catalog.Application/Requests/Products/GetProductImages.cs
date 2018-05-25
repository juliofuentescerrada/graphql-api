using System.Collections.Generic;
using Catalog.Application.Model;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProductComments : IRequest<IEnumerable<Comment>>
    {
        public int ProductId { get; set; }
    }
}