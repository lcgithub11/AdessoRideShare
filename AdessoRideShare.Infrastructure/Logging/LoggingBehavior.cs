using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AdessoRideShare.Infrastructure.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ILoggingRequest
    {
        private readonly ILoggingService _loggingService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingBehavior(ILoggingService loggingService, IHttpContextAccessor httpContextAccessor)
        {
            _loggingService = loggingService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            LogRequestDetails(request);
            var response = await next();
            return response;
        }

        private void LogRequestDetails(TRequest request)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var ipAddress = httpContext?.Connection.RemoteIpAddress?.ToString();
            var httpMethod = httpContext?.Request.Method;
            var requestParameters = JsonConvert.SerializeObject(request);
            var user = httpContext?.User?.Identity?.Name ?? "?";

            var logDetail = new LogDetail
            {
                MethodName = httpMethod,
                Parameters = requestParameters,
                User = user
            };

            var logMessage = JsonConvert.SerializeObject(logDetail);
            _loggingService.Info(logMessage);
        }
    }
}
