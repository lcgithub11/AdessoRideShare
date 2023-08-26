using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace AdessoRideShare.Infrastructure.Caching
{
    public class CacheRemovingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>, ICustomCacheRemovingRequest
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CacheRemovingBehavior<TRequest, TResponse>> _logger;

        public CacheRemovingBehavior(IDistributedCache cache, ILogger<CacheRemovingBehavior<TRequest, TResponse>> logger
        )
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;
            if (request.ShouldInvalidateCache) return await next();

            async Task<TResponse> GetResponseAndRemoveCache()
            {
                response = await next();
                await _cache.RemoveAsync(request.CacheKey, cancellationToken);
                return response;
            }

            response = await GetResponseAndRemoveCache();
            _logger.LogInformation($"Deleted from cache : {request.CacheKey}");

            return response;
        }
    }
}
