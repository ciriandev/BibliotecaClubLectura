namespace BibliotecaAPI.DTOs
{
    public class DonacionDTO
    {
        public int LibrosId { get; set; }
        public int UsuariosId { get; set; }
        public DateTime FechaDonacion { get; set; }
        public int CantidadDonada { get; set; }
    }
}