using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppiGraphql.GraphQL;
using WebAppiGraphql.Models;
using WebAppiGraphql.Services;

namespace WebAppiGraphql.Controllers
{
    [Route("/graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        public DataContext DataContext { get; }
        public GraphQLController(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            Inputs inputs = query.Variables.ToInputs();
            Schema schema = new Schema
            {
                Query = new PeopleQuery(DataContext)
            };
            DocumentExecuter documentExecuter = new DocumentExecuter();
            ExecutionResult result = await
                documentExecuter.ExecuteAsync(options =>
                {                    
                    options.Schema = schema;
                    options.Query = query.Query;
                    options.OperationName = query.OperationName;
                    options.Inputs = inputs;
                });
            if (result.Errors?.Count > 0) return BadRequest();           
            return Ok(result.Data);
        }
    }
}