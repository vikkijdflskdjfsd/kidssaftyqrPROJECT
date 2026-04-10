using KidsSafetyQR.Models;
using Microsoft.EntityFrameworkCore;

namespace KidsSafetyQR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<ScanLog> ScanLogs { get; set; }
    }
}
