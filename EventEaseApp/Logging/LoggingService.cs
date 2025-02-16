using Microsoft.Extensions.Logging;

namespace EventEaseApp.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogException(Exception ex, string? message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                _logger.LogError(ex, "Exception occurred.");
            }
            else
            {
                _logger.LogError(ex, $"Exception occurred: {message}");
            }
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
