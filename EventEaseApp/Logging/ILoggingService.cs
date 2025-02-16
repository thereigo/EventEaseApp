namespace EventEaseApp.Logging
{
    public interface ILoggingService
    {
        void LogException(Exception ex, string message = null);
        void LogInformation(string message);
    }
}
