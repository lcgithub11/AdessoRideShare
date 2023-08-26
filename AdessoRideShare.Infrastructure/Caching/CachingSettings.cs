namespace AdessoRideShare.Infrastructure.Caching
{
    public class CachingSettings
    {
        // If using caching we set 1 hour for lifetime default
        public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(60); 
    }
}
