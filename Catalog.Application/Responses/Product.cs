using Catalog.Application.Requests.Products;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application.Responses
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
    }

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(IMediator mediator)
        {
            Name = nameof(Product);

            Field(e => e.Id);

            Field(e => e.Name, nullable: true);

            Field(e => e.BrandName, nullable: true);

            Field<ListGraphType<ImageType>>(
                name: "images",
                description: "Product images",
                resolve: context => mediator.Send(new GetProductImages { ProductId = context.Source.Id }).Result);

            Field<ListGraphType<CommentType>>(
                name: "comments",
                description: "Product comments",
                resolve: context => mediator.Send(new GetProductComments { ProductId = context.Source.Id }).Result);
        }
    }
}