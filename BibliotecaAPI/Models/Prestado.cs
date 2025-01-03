using System;

namespace BibliotecaAPI.Models
{
    public class Prestado
    {
        public int PrestadosId { get; set; } // Clave primaria
        public int LibrosId { get; set; }    // Clave foránea
        public int UsuariosId { get; set; }  // Clave foránea
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public required string Estado { get; set; }

        // Relaciones con `Libro` y `Usuario`
        public required Libro Libro { get; set; }
        public required Usuario Usuario { get; set; }
    }
}