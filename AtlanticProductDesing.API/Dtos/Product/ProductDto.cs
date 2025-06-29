// Crear producto dto
namespace AtlanticProductDesing.API.Dtos.Product
{
    public class ProductDto
    {
        public long? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public required ICollection<Client> Clients { get; set; }
    }
}