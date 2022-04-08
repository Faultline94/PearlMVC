using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PearlMVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PearlMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString
    ("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PearlNecklaceDB; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False")));
//"PearlMVCContext"


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
