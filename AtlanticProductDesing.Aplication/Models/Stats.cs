namespace AtlanticProductDesing.Application.Models
{
    public class Stats
    {
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public double ActualBalance { get; set; }
        public IEnumerable<StatDetail> StatDetails { get; set; }
        public string MasterAddress { get; set; } = string.Empty;
    }
}
