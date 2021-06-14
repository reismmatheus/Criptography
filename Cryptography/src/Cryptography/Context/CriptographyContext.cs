using Cryptography.Repositories.Model;
using Microsoft.EntityFrameworkCore;

namespace Cryptography.Context
{
    public class CriptographyContext : DbContext
    {
        public CriptographyContext(DbContextOptions<CriptographyContext> options) : base(options) { }

        public DbSet<CriptographyCard> CriptographyCards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
