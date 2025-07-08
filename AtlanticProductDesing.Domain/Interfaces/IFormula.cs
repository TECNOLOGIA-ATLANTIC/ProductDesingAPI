namespace AtlanticProductDesing.Domain.Entities
{
    public interface IFormula
    {
        string Name { get; set; }
        string Expression { get; set; }
        string? Description { get; set; }
    }
}   