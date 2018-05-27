using Catalog.Application.Requests.Products;
using Catalog.Application.Responses;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application
{
    public class CatalogMutation : ObjectGraphType<object>
    {
        public CatalogMutation(IMediator mediator)
        {
            Field<CommentType>(
                name: "addComment",
                description: "Add a comment to a product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddCommentInputType>> { Name = "request" }),
                resolve: context =>
                {
                    var request = context.GetArgument<AddComment>("request");
                    return mediator.Send(request).Result;
                });
        }
    }
}