using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplicationMVC.Services;
using WebApplicationMVC.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionStringMysql = builder.Configuration.GetConnectionString("WebApplicationMVCContext");
builder.Services.AddDbContext<WebApplicationMVCContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("WebApplicationMVCContext")))); // parte ausente no fork de medinasp
builder.Services.AddScoped<SeedingService>();
// Adicionado para fazer o uso do Mysql no lugar de usar o codigo no Startup (versao anterior)

//builder.Services.AddDbContext<WebApplicationMVCContext>(options =>
//options.UseMySql(builder.Configuration.GetConnectionString("WebApplicationMVCContext"),
//ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("WebApplicationMVCContext")),
//builder => builder.MigrationsAssembly("WebApplicationMVC")));




builder.Services.AddControllersWithViews();
// Add services to the container.


var app = builder.Build();
app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();
// Adicionado para fazer o seed no lugar de usar no Startup (versao anterior) - repopular o banco caso n esteja previamente

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
