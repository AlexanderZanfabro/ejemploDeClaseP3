﻿// <auto-generated />
using System;
using LogicaAccesoDatos.RepositorioEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    [DbContext(typeof(Libreria2023Context))]
    [Migration("20230911120058_AutoresPublicacionesFavs_Add")]
    partial class AutoresPublicacionesFavs_Add
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutorPublicacion", b =>
                {
                    b.Property<int>("AutoresId")
                        .HasColumnType("int");

                    b.Property<int>("MisPublicacionesId")
                        .HasColumnType("int");

                    b.HasKey("AutoresId", "MisPublicacionesId");

                    b.HasIndex("MisPublicacionesId");

                    b.ToTable("AutorPublicacion");
                });

            modelBuilder.Entity("AutorPublicacion1", b =>
                {
                    b.Property<int>("MisAutoresFansId")
                        .HasColumnType("int");

                    b.Property<int>("MisPublicacionesFavoritasId")
                        .HasColumnType("int");

                    b.HasKey("MisAutoresFansId", "MisPublicacionesFavoritasId");

                    b.HasIndex("MisPublicacionesFavoritasId");

                    b.ToTable("AutorPublicacion1");
                });

            modelBuilder.Entity("AutorTema", b =>
                {
                    b.Property<int>("AutoresUsanTemaId")
                        .HasColumnType("int");

                    b.Property<int>("TemasAbordadosId")
                        .HasColumnType("int");

                    b.HasKey("AutoresUsanTemaId", "TemasAbordadosId");

                    b.HasIndex("TemasAbordadosId");

                    b.ToTable("AutorTema");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaDefuncion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Biografia", b =>
                {
                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoCivil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LugarNacimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId");

                    b.ToTable("Biografia");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editoriales");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Publicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPaginas")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenPortada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MiEditorialId")
                        .HasColumnType("int");

                    b.Property<int>("MiTemaId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioSugerido")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockMinimo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiEditorialId");

                    b.HasIndex("MiTemaId");

                    b.ToTable("Publicaciones");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Publicacion");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Telefono", b =>
                {
                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoArea")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorId", "CodigoArea", "Numero");

                    b.ToTable("Telefono");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Tema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Libro", b =>
                {
                    b.HasBaseType("Libreria.LogicaNegocio.Entidades.Publicacion");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Libro");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Revista", b =>
                {
                    b.HasBaseType("Libreria.LogicaNegocio.Entidades.Publicacion");

                    b.Property<int>("Anho")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("TablaContenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Revista");
                });

            modelBuilder.Entity("AutorPublicacion", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Autor", null)
                        .WithMany()
                        .HasForeignKey("AutoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libreria.LogicaNegocio.Entidades.Publicacion", null)
                        .WithMany()
                        .HasForeignKey("MisPublicacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutorPublicacion1", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Autor", null)
                        .WithMany()
                        .HasForeignKey("MisAutoresFansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libreria.LogicaNegocio.Entidades.Publicacion", null)
                        .WithMany()
                        .HasForeignKey("MisPublicacionesFavoritasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutorTema", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Autor", null)
                        .WithMany()
                        .HasForeignKey("AutoresUsanTemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libreria.LogicaNegocio.Entidades.Tema", null)
                        .WithMany()
                        .HasForeignKey("TemasAbordadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Autor", b =>
                {
                    b.OwnsOne("Libreria.LogicaNegocio.Entidades.Direccion", "MiDireccion", b1 =>
                        {
                            b1.Property<int>("AutorId")
                                .HasColumnType("int");

                            b1.Property<string>("Calle")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("NumeroPuerta")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("AutorId");

                            b1.ToTable("Autores");

                            b1.WithOwner()
                                .HasForeignKey("AutorId");
                        });

                    b.Navigation("MiDireccion")
                        .IsRequired();
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Biografia", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Autor", "MiAutor")
                        .WithOne("MiBiografia")
                        .HasForeignKey("Libreria.LogicaNegocio.Entidades.Biografia", "AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiAutor");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Publicacion", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Editorial", "MiEditorial")
                        .WithMany()
                        .HasForeignKey("MiEditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Libreria.LogicaNegocio.Entidades.Tema", "MiTema")
                        .WithMany()
                        .HasForeignKey("MiTemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiEditorial");

                    b.Navigation("MiTema");
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Telefono", b =>
                {
                    b.HasOne("Libreria.LogicaNegocio.Entidades.Autor", null)
                        .WithMany("MisTelefonos")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Libreria.LogicaNegocio.Entidades.Autor", b =>
                {
                    b.Navigation("MiBiografia")
                        .IsRequired();

                    b.Navigation("MisTelefonos");
                });
#pragma warning restore 612, 618
        }
    }
}
