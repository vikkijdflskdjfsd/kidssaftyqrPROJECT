using KidsSafetyQR.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ IMPORTANT FOR RENDER
builder.WebHost.UseUrls("http://0.0.0.0:10000");

// ✅ MVC + Views
builder.Services.AddControllersWithViews();

// ✅ Session
builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// ✅ DB Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

var app = builder.Build();

// ✅ Middleware
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

// ✅ Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();