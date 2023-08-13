using Microsoft.EntityFrameworkCore;
using Supa.DataAccess.Models;

namespace Supa.DataAccess.Data
{
    public class SupaDbContext : DbContext
    {
        public DbSet<NetworkInfoModel> NetworkInfoModels { get; set; }
        public SupaDbContext(DbContextOptions<SupaDbContext> options)
            : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
