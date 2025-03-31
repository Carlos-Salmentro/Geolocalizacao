using Microsoft.EntityFrameworkCore;
using Projeto_Geo.Domain;


namespace Projeto_Geo.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BaseDados> BaseDados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<BaseDados>().HasKey(x => x.Id);
        }

        

    }
}
