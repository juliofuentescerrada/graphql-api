using System;
using GraphQL.Types;

namespace Catalog.Application
{
    public class CatalogSchema : Schema
    {
        public CatalogSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = resolveType(typeof(CatalogQuery)) as IObjectGraphType;
        }
    }
}