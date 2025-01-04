using System;

namespace BibliotecaAPI.Models
{
    public class Donacion
{
    public int DonacionesId { get; set; }  // Asegúrate de que esta propiedad esté definida
    public int LibrosId { get; set; }
    public string Donante { get; set; }
    public DateTime FechaDonacion { get; set; }
    public int CantidadDonada { get; set; }
    
    // Propiedad de navegación si existe una relación con 'Libros'
    public virtual Libro Libro { get; set; }
}

}