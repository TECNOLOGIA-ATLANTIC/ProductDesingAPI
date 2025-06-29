namespace AtlanticProductDesing.Application.DTOs
{
    public class ProgramDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DondeDto Donde { get; set; }
        public DuracionDto Duracion { get; set; }
    }
}
