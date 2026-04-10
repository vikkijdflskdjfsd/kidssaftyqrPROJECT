using KidsSafetyQR.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ MVC + Views
builder.Services.AddControllersWithViews();

// ✅ Session
builder.Services.AddSession();

// ✅ DB Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// ✅ Middleware
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseSession();

// ✅ Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();