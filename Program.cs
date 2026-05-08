using KidsSafetyQR.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Render Port Binding
builder.WebHost.UseUrls("http://0.0.0.0:10000");

// ✅ MVC + Views
builder.Services.AddControllersWithViews();

// ✅ Session Support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// ✅ SQL Server Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    ));

var app = builder.Build();

// ✅ SHOW ACTUAL ERRORS
app.UseDeveloperExceptionPage();

// ✅ Middleware
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

// ✅ Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();