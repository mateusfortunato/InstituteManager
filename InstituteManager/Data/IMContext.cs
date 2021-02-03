using InstituteManager.Models;
using Microsoft.EntityFrameworkCore;

namespace InstituteManager.Data
{
    public class IMContext : DbContext
    {
        public IMContext(DbContextOptions<IMContext> options) : base(options) {}
        
        public DbSet<Department>  Departments { get; set; }
        public DbSet<Institute> Institutes { get; set; }
    }
}