using Microsoft.Extensions.Logging;

public interface ILoggingService
{
    void Info(string message);
    void Warn(string message);
    void Debug(string message);
    void Error(string message);
}

public class SerilogLoggingService : ILoggingService
{
    protected readonly ILogger _logger;

    public SerilogLoggingService(ILogger logger)
    {
        _logger = logger;
    }

    public void Info(string message)
    {
        _logger.LogInformation(message);
    }

    public void Warn(string message)
    {
        _logger.LogWarning(message);
    }

    public void Debug(string message)
    {
        _logger.LogDebug(message);
    }

    public void Error(string message)
    {
        _logger.LogError(message);
    }
}
