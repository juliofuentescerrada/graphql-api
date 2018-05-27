using Catalog.Application.Responses;
using GraphQL.Types;
using MediatR;

namespace Catalog.Application.Requests.Products
{
    public class AddComment : IRequest<Comment>
    {
        public int ProductId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
    }

    public class AddCommentInputType : InputObjectGraphType
    {
        public AddCommentInputType()
        {
            Name = nameof(AddCommentInputType);
            Field<NonNullGraphType<IntGraphType>>(nameof(AddComment.ProductId));
            Field<NonNullGraphType<StringGraphType>>(nameof(AddComment.Text));
            Field<NonNullGraphType<StringGraphType>>(nameof(AddComment.Author));
        }
    }
}