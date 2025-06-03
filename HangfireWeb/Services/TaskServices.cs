namespace HangfireWeb.Services
{
    public class TaskServices: ITaskServices
    {
        public void SendWelcomeEmail()
        {
            Console.WriteLine($"📧 Welcome email sent at {DateTime.Now}");
            // You can simulate sending via SMTP here
        }

        public void CleanLogs()
        {
            Console.WriteLine($"🧹 Log cleanup started at {DateTime.Now}");
            Console.WriteLine($"All Logs Successfully Cleaned at {DateTime.Now}");
            // Simulate file deletion or archiving
        }

        public void GenerateDailyReport()
        {
            Console.WriteLine($"📊 Report generated at {DateTime.Now}");
            // Simulate creating and saving a report
        }
    }

}
