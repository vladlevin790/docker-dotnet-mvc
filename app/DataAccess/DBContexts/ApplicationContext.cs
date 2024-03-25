using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.DataAccess.Implementations.Entities;

namespace app.DataAccess.DBContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<ToDoElement>? ToDoElements { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ToDoElement>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(); 
            });
        }

    }
}