using Microsoft.EntityFrameworkCore;

namespace InstituteManager.Data
{
    public class IMContext : DbContext
    {
        public IMContext(DbContextOptions<IMContext> options) : base(options)
        {
            
        }
    }
}