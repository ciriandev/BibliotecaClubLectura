namespace BibliotecaAPI.Models
{
    public class Usuario
    {
        public int UsuariosId { get; set; } // Clave primaria
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
    }
}
