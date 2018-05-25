using Catalog.Application.Model;
using Catalog.Application.Requests.Brands;
using Catalog.Application.Requests.Products;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application
{
    public class CatalogQuery : ObjectGraphType
    {
        public CatalogQuery()
        {
        }

        public CatalogQuery(IMediator mediator)
        {
            Name = "Query";

            Field<ListGraphType<ProductType>>(
                name: "products",
                description: "List of all products",
                resolve: context => mediator.Send(new GetProductList()));

            Field<ProductType>(
                name: "product",
                description: "Single product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return mediator.Send(new GetProduct { Id = id });
                });

            Field<ListGraphType<BrandType>>(
                name: "brands",
                description: "List of all brands",
                resolve: context => mediator.Send(new GetBrandList()));

            Field<BrandType>(
                name: "brand",
                description: "Single brand",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var result = mediator.Send(new GetBrand { Id = id });
                    return result;
                });
        }
    }
}