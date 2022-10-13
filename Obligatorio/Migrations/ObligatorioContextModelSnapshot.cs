﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework;

namespace Obligatorio.LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(ObligatorioContext))]
    partial class ObligatorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("PBI")
                        .HasColumnType("float");

                    b.Property<int>("Poblacion")
                        .HasColumnType("int");

                    b.Property<int>("Region")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hora")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Seleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadApostadores")
                        .HasColumnType("int");

                    b.Property<int>("Grupo")
                        .HasColumnType("int");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("Puntuacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Selecciones");
                });

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Pais", b =>
                {
                    b.OwnsOne("Obligatorio.LogicaNegocio.ValueObjects.CodigoPais", "CodigoISO", b1 =>
                        {
                            b1.Property<int>("PaisId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("CodigoISO_Alfa3")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PaisId");

                            b1.ToTable("Paises");

                            b1.WithOwner()
                                .HasForeignKey("PaisId");
                        });

                    b.OwnsOne("Obligatorio.LogicaNegocio.ValueObjects.ImagenPais", "Imagen", b1 =>
                        {
                            b1.Property<int>("PaisId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("URL")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PaisId");

                            b1.ToTable("Paises");

                            b1.WithOwner()
                                .HasForeignKey("PaisId");
                        });

                    b.OwnsOne("Obligatorio.LogicaNegocio.ValueObjects.NombrePais", "Nombre", b1 =>
                        {
                            b1.Property<int>("PaisId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Nombre")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PaisId");

                            b1.ToTable("Paises");

                            b1.WithOwner()
                                .HasForeignKey("PaisId");
                        });
                });

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Partido", b =>
                {
                    b.OwnsMany("Obligatorio.LogicaNegocio.ValueObjects.InfoSeleccionPartido", "Infoselpar", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Amarillas")
                                .HasColumnType("int");

                            b1.Property<int>("Goles")
                                .HasColumnType("int");

                            b1.Property<int>("PartidoId")
                                .HasColumnType("int");

                            b1.Property<int>("RojasAcumuladas")
                                .HasColumnType("int");

                            b1.Property<int>("RojasDirectas")
                                .HasColumnType("int");

                            b1.Property<int>("SeleccionId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("PartidoId");

                            b1.HasIndex("SeleccionId");

                            b1.ToTable("InfoSeleccionPartido");

                            b1.WithOwner("Partido")
                                .HasForeignKey("PartidoId");

                            b1.HasOne("Obligatorio.LogicaNegocio.Entidades.Seleccion", "Seleccion")
                                .WithMany()
                                .HasForeignKey("SeleccionId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();
                        });
                });

            modelBuilder.Entity("Obligatorio.LogicaNegocio.Entidades.Seleccion", b =>
                {
                    b.HasOne("Obligatorio.LogicaNegocio.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Obligatorio.LogicaNegocio.ValueObjects.PersonaContacto", "Contacto", b1 =>
                        {
                            b1.Property<int>("SeleccionId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Email")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Nombre")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Telefono")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SeleccionId");

                            b1.ToTable("Selecciones");

                            b1.WithOwner()
                                .HasForeignKey("SeleccionId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
