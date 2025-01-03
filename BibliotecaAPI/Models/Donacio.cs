using System;

namespace BibliotecaAPI.Models
{
    public class Donacion
    {
        public int DonacionesId { get; set; } // Clave primaria
        public int LibrosId { get; set; }     // Clave foránea
        public required string Donante { get; set; }
        public DateTime FechaDonacion { get; set; }
        public int CantidadDonada { get; set; }

        // Relación con `Libro`
        public required Libro Libro { get; set; }
    }
}