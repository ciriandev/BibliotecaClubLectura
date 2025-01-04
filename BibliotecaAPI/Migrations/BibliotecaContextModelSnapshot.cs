﻿// <auto-generated />
using System;
using BibliotecaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotecaAPI.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    partial class BibliotecaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BibliotecaAPI.Models.Donacion", b =>
                {
                    b.Property<int>("DonacionesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadDonada")
                        .HasColumnType("int");

                    b.Property<string>("Donante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaDonacion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LibrosId")
                        .HasColumnType("int");

                    b.HasKey("DonacionesId");

                    b.HasIndex("LibrosId");

                    b.ToTable("Donaciones");
                });

            modelBuilder.Entity("BibliotecaAPI.Models.Libro", b =>
                {
                    b.Property<int>("LibrosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LibrosId");

                    b.ToTable("Libros");
                });

            modelBuilder.Entity("BibliotecaAPI.Models.Prestado", b =>
                {
                    b.Property<int>("PrestadosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaPrestamo")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LibrosId")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("int");

                    b.HasKey("PrestadosId");

                    b.HasIndex("LibrosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Prestados");
                });

            modelBuilder.Entity("BibliotecaAPI.Models.Usuario", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UsuariosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BibliotecaAPI.Models.Donacion", b =>
                {
                    b.HasOne("BibliotecaAPI.Models.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("LibrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");
                });

            modelBuilder.Entity("BibliotecaAPI.Models.Prestado", b =>
                {
                    b.HasOne("BibliotecaAPI.Models.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("LibrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotecaAPI.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Libro");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}