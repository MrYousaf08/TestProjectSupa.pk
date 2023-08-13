using Microsoft.EntityFrameworkCore;

namespace SupaWebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NetworkConfiguration> NetworkConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NetworkConfiguration>()
                .HasKey(nc => nc.NetworkLabelName); // Specify NetworkLabelName as the primary key
        }
    }

}
