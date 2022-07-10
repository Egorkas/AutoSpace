using StackExchange.Profiling.Storage;
using Store.Application;
using Store.Application.Common.Mappings;
using Store.Application.Interfaces;
using Store.Persistence;
using System.Reflection;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .WriteTo.File("StoreWebLog-.txt", rollingInterval:
        RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddMiniProfiler(
      options =>
      {
          // (Optional) Path to use for profiler URLs, default is /mini-profiler-resources
          options.RouteBasePath = "/profiler";
          (options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(60);
          // (Optional) Control which SQL formatter to use, InlineFormatter is the default
          options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
      }).AddEntityFramework();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IStoreDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllersWithViews();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<StoreDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception exception)
    {
        Log.Fatal(exception, "An error occured while app initialization");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiniProfiler();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();


