using System.Collections.Generic;
using System.Linq;
using Catalog.Application.Requests.Products;
using GraphQL.DataLoader;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application.Responses
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(IDataLoaderContextAccessor accessor, IMediator mediator)
        {
            Name = nameof(Product);

            Field(e => e.Id);

            Field(e => e.Name, nullable: true);

            Field(e => e.BrandName, nullable: true);

            Field<ListGraphType<ImageType>, IEnumerable<Image>>()
                .Name("images")
                .Description("Product images")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Image>(
                        nameof(GetProductImages), 
                        keys => mediator.Send(new GetProductImages { ProductIds = keys.ToArray() }));

                    return loader.LoadAsync(context.Source.Id);
                });

            Field<ListGraphType<CommentType>, IEnumerable<Comment>>()
                .Name("comments")
                .Description("Product comments")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Comment>(
                        nameof(GetProductComments), 
                        keys => mediator.Send(new GetProductComments { ProductIds = keys.ToArray() }));

                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}