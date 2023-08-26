namespace AdessoRideShare.Infrastructure.Caching
{
    public interface ICachableRequest
    {
        bool ShouldInvalidateCache { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
