using Microsoft.EntityFrameworkCore;
using PhotoProfile.Info.Interface;
using PhotoProfile.Info.Repository;
using Postgres.Context.DBContext;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}
);

var app = builder.Build();

builder.Services.AddDbContext<NpgsqlContext>(options =>
options.UseNpgsql(config["ConnectionStrings:PostgreSQL"], b => b.MigrationsAssembly("ActyIn")));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<IFile, ImageService>();
builder.Services.AddScoped<ImageService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
