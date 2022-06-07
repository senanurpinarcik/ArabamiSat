using ArabamiSatWeb.Helper_Codes;
using ArabamiSatWeb.Models.Base;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(10));
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

SessionHelper.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}"
    );
app.MapControllerRoute(name: "arabam",
    pattern: "arabam",
    defaults: new { controller = "Arabam", action = "Arabalarim" });

app.Run();
