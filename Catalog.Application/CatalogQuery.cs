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

            Field<ListGraphType<BrandType>>(
                name: "brands",
                description: "List of all brands",
                resolve: context => mediator.Send(new GetBrandList()));
        }
    }
}