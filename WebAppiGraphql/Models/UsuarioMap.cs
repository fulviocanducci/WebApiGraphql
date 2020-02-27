using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebAppiGraphql.Models
{
   public class UsuarioMap : IEntityTypeConfiguration<Usuario>
   {
      public void Configure(EntityTypeBuilder<Usuario> builder)
      {
         builder.ToTable("usuario");
         builder.HasKey(x => x.Id);
         builder.Property(x => x.Id)
            .HasColumnName("id"); 
         builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .HasMaxLength(100)
            .IsRequired(); 
      }
   }
}
