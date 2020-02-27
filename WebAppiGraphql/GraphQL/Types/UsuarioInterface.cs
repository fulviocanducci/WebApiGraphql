using GraphQL.Types;
using WebAppiGraphql.Models;
namespace WebAppiGraphql.GraphQL.Types
{
   public class UsuarioInterface : InterfaceGraphType<Usuario>
   {
      public UsuarioInterface()
      {
         Name = "Usuario";
         Field(x => x.Id).Name("id").Description("Id do usuário");
         Field(x => x.Nome).Name("nome").Description("Nome do usuário");
         Field<ListGraphType<UsuarioInterface>>("usuarios");
         ResolveType = x => { return new UsuarioType(); };
      }
   }

   public class UsuarioType: ObjectGraphType<Usuario>
   {
      public UsuarioType()
      {
         Name = "UsuarioType";
         Interface<UsuarioInterface>();
      }
   }

   public class UsuarioInputType : InputObjectGraphType
   {
      public UsuarioInputType()
      {       
         Field<UsuarioInterface>();
      }
   }
}
