using Microsoft.EntityFrameworkCore;


namespace Projeto_Geo.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
    }
}
