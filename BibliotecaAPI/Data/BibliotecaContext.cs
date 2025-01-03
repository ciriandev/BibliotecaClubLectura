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
            // Configuraciones adicionales para relaciones, índices, etc.
            modelBuilder.Entity<Donacion>()
                .HasOne(d => d.Libro)
                .WithMany()  // Donaciones no tienen una lista de Libros relacionados.
                .HasForeignKey(d => d.LibrosId);

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
