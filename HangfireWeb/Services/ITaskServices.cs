namespace HangfireWeb.Services
{
    public interface ITaskServices
    {
        void SendWelcomeEmail();
        void CleanLogs();
        void GenerateDailyReport();

    }
}