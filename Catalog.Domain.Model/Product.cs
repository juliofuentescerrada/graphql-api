using System;
using System.Collections.Generic;

namespace Catalog.Domain.Model
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Brand Brand { get; private set; }

        private readonly List<Image> _images = new List<Image>();
        public IEnumerable<Image> Images => _images.AsReadOnly();

        private readonly List<Comment> _comments = new List<Comment>();
        public IEnumerable<Comment> Comments => _comments.AsReadOnly();

        private Product() { }

        public static Product Create(string name, Brand brand) => new Product { Name = name, Brand = brand };

        public void AddImage(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            _images.Add(image);
        }

        public void AddComment(Comment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            _comments.Add(comment);
        }
    }
}
