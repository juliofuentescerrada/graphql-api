using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Requests.Brands
{
    public class GetBrand : IRequest<Brand>
    {
        public int Id { get; set; }
    }
}