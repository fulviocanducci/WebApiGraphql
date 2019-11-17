using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppiGraphql.GraphQL.Types;
using WebAppiGraphql.Models;
using WebAppiGraphql.Services;

namespace WebAppiGraphql.GraphQL
{
  public class Queries : ObjectGraphType
  {
    public DataContext DataContext { get; }
    public Queries(DataContext dataContext)
    {
      DataContext = dataContext;
      ConfigurationPeopleTypeToQuery();
      ConfigurationPhoneTypeToQuery();
    }

    private void ConfigurationPhoneTypeToQuery()
    {
      Field<PhoneType>("phone",
          arguments: new QueryArguments(
                  new QueryArgument<IdGraphType> { Name = "id" },
                  new QueryArgument<BooleanGraphType> { Name = "load", DefaultValue = false }
                  ),          
          resolve: context =>
          {
            int id = context.GetArgument<int>("id");
            bool load = context.GetArgument<bool>("load");
            IQueryable<Phone> query = DataContext.Phone.AsNoTracking();
            if (load)
            {
              query = query.Include(x => x.People);
            }
            return query.FirstOrDefault(x => x.Id == id);
          });
    }

    private void ConfigurationPeopleTypeToQuery()
    {
      //{"query":"{people(id:1,load:true) {name,created,id,phones{ddd,number}}}"}
      Field<PeopleType>("people",
          arguments: new QueryArguments(
                  new QueryArgument<IdGraphType> { Name = "id" },
                  new QueryArgument<BooleanGraphType> { Name = "load", DefaultValue = false }
                  ),
          resolve: context =>
          {
            int id = context.GetArgument<int>("id");
            bool load = context.GetArgument<bool>("load");
            IQueryable<People> query = DataContext.People.AsNoTracking();
            if (load)
            {
              query = query.Include(x => x.Phones);
            }
            return query.FirstOrDefault(x => x.Id == id);
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
