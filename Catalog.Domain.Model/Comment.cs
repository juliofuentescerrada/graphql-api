using System;

namespace Catalog.Domain.Model
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public string Author { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Comment() { }

        public static Comment Create(string text, string author)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException(nameof(text));
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException(nameof(author));

            return new Comment { Text = text, Author = author, CreatedAt = DateTime.Now };
        }
    }
}