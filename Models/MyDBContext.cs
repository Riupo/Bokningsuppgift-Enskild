using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Bokning_G.Models
{
    public class MyDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=tcp:bokningsapp.database.windows.net,1433;Initial Catalog=Bokningsapp SQL;Persist Security Info=True;User ID=BilalAdmin;Password=20Bilal20;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
        }
        public DbSet<Bokningar> Bokningarna { get; set; }
        public DbSet<SkapaKonto> Skapade { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SkapaKonto>()
                .HasIndex(u => u.Användernamn)
                .IsUnique();
            builder.Entity<SkapaKonto>()
                 .HasIndex(u => u.Mail)
                  .IsUnique();
        }
    }
}

