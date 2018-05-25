using System;

namespace Catalog.Domain.Model
{
    public class Image
    {
        public int Id { get; private set; }
        public string Url { get; private set; }

        private Image() { }

        public static Image Create(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException(nameof(url));

            return new Image { Url = url };
        }
    }
}