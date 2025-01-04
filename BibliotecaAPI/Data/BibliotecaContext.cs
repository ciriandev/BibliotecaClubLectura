using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        // Define los DbSets para cada tabla
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Donacion> Donaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestado> Prestados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la clave primaria de Donacion
            modelBuilder.Entity<Donacion>()
                .HasKey(d => d.DonacionesId);  // Asegúrate de definir la clave primaria

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.UsuariosId);

            modelBuilder.Entity<Prestado>()
                .HasKey(p => p.PrestadosId);
            
            modelBuilder.Entity<Libro>()
                .HasKey(l => l.LibrosId);

            // Configuración de la relación entre Donacion y Libro
            modelBuilder.Entity<Donacion>()
                .HasOne(d => d.Libro)
                .WithMany()
                .HasForeignKey(d => d.LibrosId);

            // Configuración de las relaciones para las otras entidades
            modelBuilder.Entity<Prestado>()
                .HasOne(p => p.Libro)
                .WithMany()
                .HasForeignKey(p => p.LibrosId);

            modelBuilder.Entity<Prestado>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey(p => p.UsuariosId);
        }
    }
}
