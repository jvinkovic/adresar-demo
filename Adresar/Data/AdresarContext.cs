using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class AdresarContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./AdresarSQLite.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Contact>().ToTable("Contacts", "dbo");
            modelBuilder.Entity<Address>().ToTable("Addresses", "dbo");

            base.OnModelCreating(modelBuilder);
        }
    }
}