using Hangfire;
using HangfireWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangfireWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskServices _taskService;

        public HomeController(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ScheduleJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine($"Fire-and-forget job ran at {DateTime.Now}"));
            BackgroundJob.Schedule(() => Console.WriteLine($"Delayed job ran at {DateTime.Now}"), TimeSpan.FromSeconds(10));
            RecurringJob.AddOrUpdate("my-job", () => Console.WriteLine($"Recurring job ran at {DateTime.Now}"), Cron.Minutely);

            TempData["Message"] = "Jobs scheduled successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RunEmailJob()
        {
            BackgroundJob.Enqueue<ITaskServices>(service => service.SendWelcomeEmail());
            TempData["Message"] = "Email job scheduled!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RunLogCleanup()
        {
            BackgroundJob.Schedule<ITaskServices>(service => service.CleanLogs(), TimeSpan.FromSeconds(5));
            TempData["Message"] = "Log cleanup scheduled in 5 seconds.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RunReportGeneration()
        {
            RecurringJob.AddOrUpdate<ITaskServices>("report-job", service => service.GenerateDailyReport(), Cron.Daily);
            TempData["Message"] = "Recurring report generation job scheduled (daily).";
            return RedirectToAction("Index");
        }
    }
}
