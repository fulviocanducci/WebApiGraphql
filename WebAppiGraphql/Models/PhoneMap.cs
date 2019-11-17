using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace WebAppiGraphql.Models
{
  public class PhoneMap : IEntityTypeConfiguration<Phone>
  {
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
      builder.ToTable("phones");

      builder.HasKey(x => x.Id)
          .HasName("id");

      builder.Property(x => x.Id)
          .HasColumnName("id");

      builder.Property(x => x.PeopleId)
          .HasColumnName("peopleid");

      builder.Property(x => x.Ddd)
          .HasColumnName("ddd")
          .HasMaxLength(3);

      builder.Property(x => x.Number)
          .HasColumnName("number")
          .HasMaxLength(10);

      builder.HasOne(x => x.People)
          .WithMany(x => x.Phones)
          .HasForeignKey(x => x.PeopleId);
    }
  }
}
