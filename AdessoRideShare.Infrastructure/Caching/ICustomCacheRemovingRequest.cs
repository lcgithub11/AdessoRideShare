namespace AdessoRideShare.Infrastructure.Caching
{
    public interface ICustomCacheRemovingRequest
    {
        bool ShouldInvalidateCache { get; }
        string CacheKey { get; }
    }
}
