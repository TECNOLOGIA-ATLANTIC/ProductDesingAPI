// Crear Dto de países
namespace AtlanticProductDesing.API.Dtos.Country
{
    public class CountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;

    }
}