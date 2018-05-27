using System.Threading;
using System.Threading.Tasks;
using Catalog.Application.Requests.Products;
using Catalog.Application.Responses;
using Catalog.Domain.Services.Products;
using MediatR;

namespace Catalog.Application.RequestHandlers.Products
{
    public class AddCommentHandler : IRequestHandler<AddComment, Comment>
    {
        private readonly IProductsRepository _productsRepository;

        public AddCommentHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Comment> Handle(AddComment request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.Find(request.ProductId, cancellationToken);

            var comment = Domain.Model.Comment.Create(request.Text, request.Author);

            product.AddComment(comment);

            await _productsRepository.Save(product, cancellationToken);

            return new Comment { Text = comment.Text, Author = comment.Author, CreatedAt = comment.CreatedAt };
        }
    }
}