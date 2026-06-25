using ScoreTracker.Core.Interfaces.Services;
using ScoreTracker.Infrastructure;
using ScoreTracker.Infrastructure.Data;
using ScoreTracker.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=worldcup.db";

builder.Services.AddInfrastructure(connectionString);
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IMatchService, MatchService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    SeedData.Seed(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
