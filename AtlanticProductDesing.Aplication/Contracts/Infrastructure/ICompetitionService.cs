namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface ICompetitionService
    {
        Task SendCompetitorInfo(string competitorName, string category, List<string> items);
    }
}
