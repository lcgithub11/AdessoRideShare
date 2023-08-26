using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace AdessoRideShare.Infrastructure.Caching
{
    public class CustomCacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<CustomCacheBehavior<TRequest, TResponse>> _logger;

        public CustomCacheBehavior(IDistributedCache cache, ILogger<CustomCacheBehavior<TRequest, TResponse>> logger,
                                   IConfiguration configuration)
        {
            _cache = cache;
            _logger = logger;
        }

        private async Task RemoveFromCache(string cacheKey, CancellationToken cancellationToken)
        {
            await _cache.RemoveAsync(cacheKey, cancellationToken);
            _logger.LogInformation($"Invalidated Cache -> {cacheKey}");
        }

        private async Task<TResponse> GetResponseFromCacheOrExecute(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            byte[] cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);

            if (cachedResponse != null)
            {
                _logger.LogInformation($"Fetched from Cache -> {request.CacheKey}");
                return JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            }

            TResponse response = await ExecuteAndCacheResponse(request, next, cancellationToken);
            _logger.LogInformation($"Added to Cache -> {request.CacheKey}");
            return response;
        }

        private async Task<TResponse> ExecuteAndCacheResponse(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = await next();
            byte[] serializedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));

            var cacheOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = request.SlidingExpiration ?? TimeSpan.FromMinutes(Convert.ToInt32(60))//default 60 minutes
            };

            await _cache.SetAsync(request.CacheKey, serializedData, cacheOptions, cancellationToken);
            return response;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response;

            if (request.ShouldInvalidateCache)
            {
                await RemoveFromCache(request.CacheKey, cancellationToken);
            }

            response = await GetResponseFromCacheOrExecute(request, next, cancellationToken);

            return response;
        }
    }
}
