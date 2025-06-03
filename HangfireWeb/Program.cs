using Hangfire;
using Hangfire.MemoryStorage;
using HangfireWeb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add Hangfire services
builder.Services.AddHangfire(config =>
    config.UseMemoryStorage());

builder.Services.AddHangfireServer();

builder.Services.AddScoped<ITaskServices, TaskServices>();

var app = builder.Build();

// Use Hangfire Dashboard
app.UseHangfireDashboard("/hangfire");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
