using GraphQL.Types;
namespace WebAppiGraphql.GraphQL.Types
{
  public class PeopleAndPhoneListType : ObjectGraphType
  {
    public PeopleAndPhoneListType()
    {
      Name = "peopleandphoneoflist";
      Field<NonNullGraphType<ListGraphType<PeopleType>>>().Description("List People Type").Name("peoples");
      Field<NonNullGraphType<ListGraphType<PhoneType>>>().Description("List Phone Type").Name("phones");
    }
  }
}
