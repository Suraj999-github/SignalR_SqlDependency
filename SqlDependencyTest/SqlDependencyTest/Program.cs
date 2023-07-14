using SqlDependencyTest.SignalRHub;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddSingleton<DashboardHub>();
builder.Services.AddSingleton<SubscribeProductTableDependency>();
var app = builder.Build();
var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<DashboardHub>("/dashboardHub");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSqlTableDependency<SubscribeProductTableDependency>(connectionString);
app.Run();
