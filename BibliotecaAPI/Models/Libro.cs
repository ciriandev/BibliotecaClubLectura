namespace BibliotecaAPI.Models
{
    public class Libro
    {
        public int LibrosId { get; set; } // Clave primaria
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string ISBN { get; set; }
        public int Cantidad { get; set; }
    }
}