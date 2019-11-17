using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebAppiGraphql.Models
{
    public class PeopleMap : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("peoples");
            
            builder.HasKey(x => x.Id)
                .HasName("id");
            
            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            builder.Property(x => x.Created)
                .HasColumnName("created");

            builder.Property(x => x.Updated)
                .HasColumnName("updated");

            builder.Property(x => x.Active)
                .HasColumnName("active");
                        
        }
    }
}
