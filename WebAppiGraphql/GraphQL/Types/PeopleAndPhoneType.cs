using GraphQL.Types;
namespace WebAppiGraphql.GraphQL.Types
{
  public class PeopleAndPhoneType : ObjectGraphType
  {
    public PeopleAndPhoneType()
    {
      Name = "peopleandphone";
      Field<NonNullGraphType<PeopleType>>().Description("People Type").Name("people");
      Field<NonNullGraphType<PhoneType>>().Description("Phone Type").Name("phone");
    }
  }
}
