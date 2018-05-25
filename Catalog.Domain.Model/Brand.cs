using System;

namespace Catalog.Domain.Model
{
    public class Brand
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Brand() { }
        public static Brand Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));

            return new Brand { Name = name };
        }
    }
}