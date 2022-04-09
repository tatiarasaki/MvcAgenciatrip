using Microsoft.EntityFrameworkCore;
using MvcAgenciatrip.Models;

namespace MvcAgenciatrip.Data
{
    public class MvcAgenciatripContext : DbContext
    {
        public MvcAgenciatripContext (DbContextOptions<MvcAgenciatripContext> options)
            : base(options)
        {

        }

        public DbSet<Destino> Destino { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Promocao> Promocao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destino>().ToTable("Destino");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Promocao>().ToTable("Promocao");
        }
    }
}
