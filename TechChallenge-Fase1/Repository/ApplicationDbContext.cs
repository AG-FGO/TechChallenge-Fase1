using Microsoft.EntityFrameworkCore;
using TechChallenge_Fase1.Model;

namespace TechChallenge_Fase1.Repository
{
    public class ApplicationDbContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Acao> Acao { get; set; }
        public DbSet<Ativos> Ativos { get; set; }
    }
}
