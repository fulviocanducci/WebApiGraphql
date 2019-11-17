using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace WebAppiGraphql.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Active { get; set; }
    }

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
