using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using MasterarbeitGraphQL.Data;
using MasterarbeitGraphQL.GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MasterarbeitGraphQL.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly IRepository _repository;

        public GraphQLController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema
            {
                Query = new RootQuery(_repository)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_a =>
            {
                _a.Schema = schema;
                _a.Query = query.Query;
                _a.OperationName = query.OperationName;
                _a.Inputs = query.Variables.ToInputs();
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}