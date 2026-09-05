using Microsoft.EntityFrameworkCore;
using LocalTest.Models;

namespace LocalTest
{
    public class DentalDbContext : DbContext
    {
        public DentalDbContext(DbContextOptions<DentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<DoctorService> DoctorServices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<DoctorService>()
        .HasKey(ds => new { ds.DoctorId, ds.ServiceId });
}
    }
}