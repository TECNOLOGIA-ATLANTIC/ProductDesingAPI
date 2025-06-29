using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AtlanticProductDesing.Infrastruture.Seeds
{
    public class ProjectSeed
    {
        private readonly IMediator Mediator;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<ProjectSeed> _logger;

        public ProjectSeed(
            IMediator mediator,
            IHostEnvironment environment, ILoggerFactory loggerFactory)
        {
            Mediator = mediator;
            _environment = environment;
            _logger = loggerFactory.CreateLogger<ProjectSeed>();
        }

        public async Task Run()
        {
            string dirfile = Path.Combine(_environment.ContentRootPath, "Assets", "Json", "ProjectData.json");
            string jsonString = File.ReadAllText(dirfile);

        }
    }
}
