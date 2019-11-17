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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleMap());
        }
    }
}
