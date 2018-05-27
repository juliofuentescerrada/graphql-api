using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class GetProduct : IRequest<Product>
    {
        public int Id { get; set; }
    }
}