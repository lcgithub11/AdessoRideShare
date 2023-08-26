using Microsoft.Extensions.Logging;

namespace AdessoRideShare.Infrastructure.Logging
{
    public interface ILoggingRequest
    {
        LogLevel LogLevel { get; }
        string LogMessage { get; }
    }
}
