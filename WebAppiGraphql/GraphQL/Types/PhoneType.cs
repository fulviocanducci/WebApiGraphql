using GraphQL.Types;
using WebAppiGraphql.Models;

namespace WebAppiGraphql.GraphQL.Types
{
  public class PhoneType : ObjectGraphType<Phone>
  {
    public PhoneType()
    {
      Name = "phone";
      Field(x => x.Id).Description("Id Phone");
      Field(x => x.PeopleId).Description("PeopleId Phone");
      Field(x => x.Ddd).Description("DDD Phone");
      Field(x => x.Number).Description("Number Phone");
      Field(x => x.People, type: typeof(PeopleType)).Description("People of Phone");
    }
  }
}
