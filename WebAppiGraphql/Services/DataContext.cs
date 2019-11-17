using Microsoft.EntityFrameworkCore;
using WebAppiGraphql.Models;

namespace WebAppiGraphql.Services
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<People> People { get; set; }
        public DbSet<Phone> Phone { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleMap());
            modelBuilder.ApplyConfiguration(new PhoneMap());
        }
    }
}
