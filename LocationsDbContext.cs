using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    // move this to data access layer or EDMX folder?
    public class LocationsDbContext : DbContext
    {
        public string ConnStr => this.Database.GetDbConnection().ConnectionString;

        public virtual DbSet<Models.Location> HRDW_Locations { get; set; }
        public virtual DbSet<Models.EmployeeSelfInfo> HRDW_Employee_SelfInfo { get; set; }
        

        public LocationsDbContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {

        }

        //https://neelbhatt.com/2018/01/07/database-first-in-net-core-2-0-step-by-step-angular-4-core-2-0-crud-operation-part-i/
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<EmployeeSelfInfo>(entity =>
            {
                entity.ToTable("HRDW_Employee_SelfInfo");
                entity.HasKey(e => e.UniversalGUID);
                entity.Property(e => e.LocationID)
                    .HasMaxLength(50);
                entity.Property(e => e.EmployerID)
                    .HasColumnName("ERPEmployerID");
                
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("HRDW_Locations");
                entity.HasKey(e => e.LocationID);
            });
        }
    }
}