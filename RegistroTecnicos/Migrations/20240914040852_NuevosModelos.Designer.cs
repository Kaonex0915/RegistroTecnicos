﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240914040852_NuevosModelos")]
    partial class NuevosModelos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClientesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Whatsapp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientesId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SueldoHora")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TipoTecnicosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TecnicoId");

                    b.ToTable("Tecnicos");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.TipoTecnicos", b =>
                {
                    b.Property<int>("TipoTecnicosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoTecnicosId");

                    b.ToTable("TipoTecnicos");

                    b.HasData(
                        new
                        {
                            TipoTecnicosId = 1,
                            Descripcion = "Redes",
                            TecnicoId = 0
                        },
                        new
                        {
                            TipoTecnicosId = 2,
                            Descripcion = "Reparacion",
                            TecnicoId = 0
                        },
                        new
                        {
                            TipoTecnicosId = 3,
                            Descripcion = "Impresoras",
                            TecnicoId = 0
                        },
                        new
                        {
                            TipoTecnicosId = 4,
                            Descripcion = "Soporte",
                            TecnicoId = 0
                        },
                        new
                        {
                            TipoTecnicosId = 5,
                            Descripcion = "Celulares",
                            TecnicoId = 0
                        });
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Trabajos", b =>
                {
                    b.Property<int>("TrabajosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Monto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TecnicoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TrabajosId");

                    b.ToTable("Trabajos");
                });
#pragma warning restore 612, 618
        }
    }
}
