using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanzasPersonales.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanzasPersonales.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGasto> TiposGasto { get; set; }
        public DbSet<FondoMonetario> FondosMonetarios { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<RegistroGasto> RegistrosGastos { get; set; }
        public DbSet<DetalleGasto> DetallesGastos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Para Deposito
            modelBuilder.Entity<Deposito>()
                .Property(d => d.Monto)
                .HasPrecision(18, 2); // Define la precisión y escala

            // Para DetalleGasto
            modelBuilder.Entity<DetalleGasto>()
                .Property(dg => dg.Monto)
                .HasPrecision(18, 2); // Define la precisión y escala

            // Para Presupuesto
            modelBuilder.Entity<Presupuesto>()
                .Property(p => p.Monto)
                .HasPrecision(18, 2); // Define la precisión y escala
        }
    }
}
