using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
     : base(options) { } 
    
    public DbSet<Tecnicos> Tecnicos { get; set; }

    public DbSet<TipoTecnicos> TipoTecnicos { get; set; }

    public DbSet<Clientes> Clientes { get; set; }

    public DbSet<Trabajos> Trabajos { get; set; }

    public DbSet<Prioridades> Prioridades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoTecnicos>().HasData
        (
            new TipoTecnicos
            {
                TipoTecnicosId = 1,
                Descripcion = "Redes"
            },

            new TipoTecnicos
            {
                TipoTecnicosId = 2,
                Descripcion = "Reparacion"
            },

            new TipoTecnicos
            {
                TipoTecnicosId = 3,
                Descripcion = "Impresoras"
            },

            new TipoTecnicos
            {
                TipoTecnicosId = 4,
                Descripcion = "Soporte"
            },

            new TipoTecnicos
            {
                TipoTecnicosId = 5,
                Descripcion = "Celulares"
            }
        );
    }
}
