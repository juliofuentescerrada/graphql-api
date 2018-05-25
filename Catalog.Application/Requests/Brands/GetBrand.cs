using Catalog.Application.Model;
using MediatR;

namespace Catalog.Application.Requests.Brands
{
    public class GetBrand : IRequest<Brand>
    {
        public int Id { get; set; }
    }
}