using System.Linq;
using GraphQL.Types;
using WebAppiGraphql.Models;
using WebAppiGraphql.Services;
//https://developer.okta.com/blog/2019/04/16/graphql-api-with-aspnetcore
//https://imasters.com.br/dotnet/construindo-uma-api-graphql-com-asp-net-core-e-entity-framework-core
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

    public class Queries : ObjectGraphType
    {
        public DataContext DataContext { get; }
        public Queries(DataContext dataContext)
        {
            DataContext = dataContext;
            ConfigurationQuery();
        }
        private void ConfigurationQuery()
        {
            //{"query":"{people(id: 1) {name, created,id}}"}
            Field<PeopleType>("people",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return DataContext.People.FirstOrDefault(x => x.Id == id);
                });
            
            //{"query":"{people_filter_name(name: \"Name 2\") {name, created,id}}"}
            Field<ListGraphType<PeopleType>>("people_filter_name",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    return DataContext.People.Where(x => x.Name.Contains(name));
                });

            //{"query":"{peoples {name, created,id}}"}
            Field<ListGraphType<PeopleType>>("peoples",
                resolve: context =>
                {
                    return DataContext.People;
                });
        }
    }
}
