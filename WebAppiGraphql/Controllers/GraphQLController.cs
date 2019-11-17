using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppiGraphql.GraphQL;
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
      ExecutionResult result = null;
      using (Schema schema = new Schema())
      {
        schema.Query = new Queries(DataContext);
        void options(ExecutionOptions x)
        {
          x.Schema = schema;
          x.Query = query.Query;
          x.OperationName = query.OperationName;
          x.Inputs = inputs;
        }
        DocumentExecuter documentExecuter = new DocumentExecuter();
        result = await documentExecuter.ExecuteAsync(options);
        if (result?.Errors?.Count > 0)
        {
          return BadRequest(result.Errors);
        }
      }
      return Ok(result?.Data);
    }
  }
}