using System.Threading.Tasks;
using Catalog.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.GraphQL.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IMediator _mediator;

        public GraphQLController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}