namespace BibliotecaAPI.DTOs
{
    public class DonacionDTO
    {
        public int LibrosId { get; set; }
        public string Donante { get; set; }
        public DateTime FechaDonacion { get; set; }
        public int CantidadDonada { get; set; }
    }
}