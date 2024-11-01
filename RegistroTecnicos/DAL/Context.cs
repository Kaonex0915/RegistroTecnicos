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

    public DbSet<Articulos> Articulos { get; set; }

    public DbSet<TrabajosDetalle> TrabajoDetalle { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TipoTecnicos>().HasData
        (
            new TipoTecnicos
            {
                TipoTecnicosId = 1,
                Descripcion = "Redes",
            },

            new TipoTecnicos
            {
                TipoTecnicosId = 2,
                Descripcion = "Reparacion",

            },

            new TipoTecnicos
            {
                TipoTecnicosId = 3,
                Descripcion = "Impresoras",

            },

            new TipoTecnicos
            {
                TipoTecnicosId = 4,
                Descripcion = "Soporte",

            },

            new TipoTecnicos
            {
                TipoTecnicosId = 5,
                Descripcion = "Celulares",
            }
        );

        modelBuilder.Entity<Articulos>().HasData
        (
              new Articulos
              {
                  ArticuloId = 1,
                  Descripcion = "Mouse Logitech",
                  Costo = 350,
                  Precio = 400,
                  Existencia = 10,
              },

              new Articulos
              {
                  ArticuloId = 2,
                  Descripcion = "SSD SEAGATE 250GB",
                  Costo = 800,
                  Precio = 970,
                  Existencia = 5,
              },

              new Articulos
              {
                  ArticuloId = 3,
                  Descripcion = "Targeta grafica NVIDA RTX 30603",
                  Costo = 6000,
                  Precio = 8500,
                  Existencia = 15,
              },

              new Articulos
              {
                  ArticuloId = 4,
                  Descripcion = "Tarjeta de sonido Sound blaster 5/RX",
                  Costo = 750,
                  Precio = 1200,
                  Existencia = 4,
              },

              new Articulos
              {
                  ArticuloId = 5,
                  Descripcion =  "Placa madre Bazooka G608-1",
                  Costo = 80, 
                  Precio = 100,
                  Existencia = 30,
              }
        );
    }
}
