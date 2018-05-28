using System.Collections.Generic;
using System.Linq;
using Catalog.Application.Requests.Brands;
using GraphQL.DataLoader;
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
        public BrandType(IDataLoaderContextAccessor accessor, IMediator mediator)
        {
            Name = nameof(Brand);

            Field(e => e.Id);

            Field(e => e.Name, nullable: true);

            Field<ListGraphType<ProductType>, IEnumerable<Product>>()
                .Name("products")
                .Description("Brand products")
                .ResolveAsync(context =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Product>(
                        nameof(GetBrandProducts), 
                        keys => mediator.Send(new GetBrandProducts { BrandIds = keys.ToArray() }));

                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}