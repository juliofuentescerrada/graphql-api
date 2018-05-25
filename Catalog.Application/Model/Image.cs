using GraphQL.Types;

namespace Catalog.Application.Model
{
    public class Image
    {
        public string Url { get; set; }
    }

    public class ImageType : ObjectGraphType<Image>
    {
        public ImageType()
        {
            Name = nameof(Image);

            Field(e => e.Url);
        }
    }
}