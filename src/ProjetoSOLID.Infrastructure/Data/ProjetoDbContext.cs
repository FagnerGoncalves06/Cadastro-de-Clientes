
using Microsoft.EntityFrameworkCore;
using ProjetoSOLID.Domain.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ProjetoSOLID.Infrastructure.Data
{
    public class ProjetoDbContext : DbContext
    {
        public ProjetoDbContext(DbContextOptions<ProjetoDbContext> options) : base(options) { }
        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Cliente>().Property(c => c.Nome).IsRequired();
            modelBuilder.Entity<Cliente>().Property(c => c.Email).IsRequired();
        }
    }
}
