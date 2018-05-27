using Catalog.Application.Requests.Brands;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application.Responses
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType(IMediator mediator)
        {
            Name = nameof(Brand);

            Field(e => e.Id);

            Field(e => e.Name, nullable: true);

            Field<ListGraphType<ProductType>>(
                name: "products",
                description: "Brand products",
                resolve: context => mediator.Send(new GetBrandProducts { BrandId = context.Source.Id }).Result);
        }
    }
}