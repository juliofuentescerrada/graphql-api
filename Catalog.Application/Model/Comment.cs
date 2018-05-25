using System;
using GraphQL.Types;

namespace Catalog.Application.Model
{
    public class Comment
    {
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Name = nameof(Comment);

            Field(e => e.Text);

            Field(e => e.Author);

            Field(e => e.CreatedAt);
        }
    }
}