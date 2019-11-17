using GraphQL.Types;
using WebAppiGraphql.Models;
namespace WebAppiGraphql.GraphQL.Types
{
  public class PeopleType : ObjectGraphType<People>
  {
    public PeopleType()
    {
      Name = "people";
      Field(x => x.Id).Description("Id People");
      Field(x => x.Name).Description("Name People");
      Field(x => x.Created).Description("Created People");
      Field(x => x.Updated).Description("Update People");
      Field(x => x.Active).Description("Active People");
      Field(x => x.Phones, type: typeof(ListGraphType<PhoneType>)).Description("Phones Of People");
    }
  }
}
