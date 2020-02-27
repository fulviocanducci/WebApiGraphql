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
         ConfigurationPeopleAndPhoneToQuery();
         ConfigurationUsuarioToQueryAndInput();
      }

      private void ConfigurationUsuarioToQueryAndInput()
      {
         Field<ListGraphType<UsuarioType>>("usuarios",
           arguments: null,
           resolve: context =>
           {
              return DataContext.Usuario.ToList();
           });
      }
      private void ConfigurationPeopleAndPhoneToQuery()
      {
         //{"query":"{datas: peopleandphone(peopleId:1, phoneId:1) {people{id,name,created,updated,active} phone{id,peopleId,ddd,number}}}"}
         Field<PeopleAndPhoneType>("peopleandphone",
           arguments: new QueryArguments(
             new QueryArgument<IdGraphType> { Name = "peopleId", DefaultValue = 0 },
             new QueryArgument<IdGraphType> { Name = "phoneId", DefaultValue = 0 }
             ),
           resolve: context =>
           {
              int peopleId = context.GetArgument<int>("peopleId");
              int phoneId = context.GetArgument<int>("phoneId");
              People people = DataContext.People.Find(peopleId);
              Phone phone = DataContext.Phone.Find(phoneId);
              return new { people, phone };
           });

         //{"query":"{datas: peopleandphoneoflist {peoples{id,name,created,updated,active} phones{id,peopleId,ddd,number}}}"}
         Field<PeopleAndPhoneListType>("peopleandphoneoflist",
           resolve: context =>
           {
              IQueryable<People> peoples = DataContext.People.AsQueryable();
              IQueryable<Phone> phones = DataContext.Phone.AsQueryable();
              return new { peoples, phones };
           });
      }

      private void ConfigurationPhoneTypeToQuery()
      {
         //{"query":"{phone(id:1,load:true) {id, peopleId, ddd, number, people {name,active}}}"}
         Field<PhoneType>("phone",
             arguments: new QueryArguments(
                     new QueryArgument<IdGraphType> { Name = "id" },
                     new QueryArgument<BooleanGraphType> { Name = "load", DefaultValue = false }
                     ),
             resolve: context =>
             {
                int id = context.GetArgument<int>("id");
                bool load = context.GetArgument<bool>("load");
                IQueryable<Phone> query = DataContext.Phone
               .Where(x => x.Id == id)
               .AsNoTracking();
                return load
               ? query.Include(x => x.People).FirstOrDefault()
               : query.FirstOrDefault();
             });

         //{"query":"{phones(load:true){id,peopleId,ddd,number,people{name, active}}}"}
         Field<ListGraphType<PhoneType>>("phones",
           arguments: new QueryArguments(
                   new QueryArgument<BooleanGraphType> { Name = "load", DefaultValue = false }
                   ),
           resolve: context =>
           {
              bool load = context.GetArgument<bool>("load");
              IQueryable<Phone> query = DataContext.Phone
             .AsNoTracking();
              return load
             ? query.Include(x => x.People).AsQueryable()
             : query;
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
                IQueryable<People> query = DataContext.People
               .Where(x => x.Id == id)
               .AsTracking();
                return load
               ? query.Include(x => x.Phones).FirstOrDefault()
               : query.FirstOrDefault();
             });

         //{"query":"{people_filter_name(name:\"Name\",load:true){name,created,id,phones{ddd,number}}}"}
         Field<ListGraphType<PeopleType>>("people_filter_name",
             arguments: new QueryArguments(
               new QueryArgument<StringGraphType> { Name = "name" },
               new QueryArgument<BooleanGraphType> { Name = "load" }
               ),
             resolve: context =>
             {
                var name = context.GetArgument<string>("name");
                bool load = context.GetArgument<bool>("load");
                IQueryable<People> query = DataContext.People
               .Where(x => x.Name.Contains(name))
               .AsTracking();
                return load
               ? query.Include(x => x.Phones).AsQueryable()
               : query;
             });

         //{"query":"{peoples(load:true) {id,name,created,updated,active,phones{peopleId,ddd,number}}}"}
         Field<ListGraphType<PeopleType>>("peoples",
             arguments: new QueryArguments(
               new QueryArgument<BooleanGraphType> { Name = "load" }
               ),
             resolve: context =>
             {
                bool load = context.GetArgument<bool>("load");
                IQueryable<People> query = DataContext.People
               .AsTracking();
                return load
               ? query.Include(x => x.Phones).AsQueryable()
               : query;
             });
      }
   }
}
