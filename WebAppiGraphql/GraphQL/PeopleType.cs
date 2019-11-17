using System.Linq;
using GraphQL.Types;
using WebAppiGraphql.Models;
using WebAppiGraphql.Services;
//https://developer.okta.com/blog/2019/04/16/graphql-api-with-aspnetcore
namespace WebAppiGraphql.GraphQL
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
        }
    }

    public class PeopleQuery : ObjectGraphType
    {
        public DataContext DataContext { get; }
        public PeopleQuery(DataContext dataContext)
        {
            DataContext = dataContext;
            ConfigurationQuery();
        }
        private void ConfigurationQuery()
        {
            Field<PeopleType>("people",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return DataContext.People.FirstOrDefault(x => x.Id == id);
                });

            Field<ListGraphType<PeopleType>>("peoples",
                resolve: context =>
                {
                    return DataContext.People;
                });
        }
    }
}
