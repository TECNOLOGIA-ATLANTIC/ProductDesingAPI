using MediatR;
using NLog;

namespace AtlanticProductDesing.Application.Behaviours
{
    public class UnhandlreExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UnhandlreExceptionBehaviour()
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TResponse).Name;
                _logger.Error(ex, $"Application Request: Sucedio una excepcion para el request {0} {1}", requestName, request);
                throw;
            }
        }
    }
}
