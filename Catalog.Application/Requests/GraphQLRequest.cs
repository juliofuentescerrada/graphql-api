using System.Threading;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Execution;
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
        private readonly IDocumentExecutionListener _listener;

        public GraphQLRequestHandler(ISchema schema, IDocumentExecuter documentExecuter, IDocumentExecutionListener listener)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _listener = listener;
        }

        public async Task<ExecutionResult> Handle(GraphQLRequest request, CancellationToken cancellationToken)
        {
            return await _documentExecuter.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = request.Query;
                _.Inputs = request.Variables.ToInputs();
                _.Listeners.Add(_listener);
                _.ExposeExceptions = true;
                _.CancellationToken = cancellationToken;
            });
        }
    }
}
