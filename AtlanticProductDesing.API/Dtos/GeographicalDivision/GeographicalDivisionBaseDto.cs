namespace AtlanticProductDesing.API.Dtos.GeographicalDivision
{
    public class GeographicalDivisionBaseDto
    {
        public int CountryCode { get; set; }
        public int DepartmentCode { get; set; }
        public int CityCode { get; set; }
        public required string LocationName { get; set; }
        public required string IncentiveManagement { get; set; }
        public required string Status { get; set; }
    }
}
