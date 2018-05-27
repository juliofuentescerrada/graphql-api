using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Catalog.Application.Requests
{
    public class GraphQLRequest : IRequest<ExecutionResult>
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }

    public class GraphQLRequestHandler : IRequestHandler<GraphQLRequest, ExecutionResult>
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLRequestHandler(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        public async Task<ExecutionResult> Handle(GraphQLRequest request, CancellationToken cancellationToken)
        {
            return await _documentExecuter.ExecuteAsync(new ExecutionOptions
            {
                Schema = _schema, 
                Query = request.Query,
                Inputs = request.Variables.ToInputs()
            }).ConfigureAwait(false);
        }
    }
}
