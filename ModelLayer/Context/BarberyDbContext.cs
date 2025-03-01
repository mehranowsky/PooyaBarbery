using Microsoft.EntityFrameworkCore;
using ModelLayer.Models;

namespace ModelLayer.Context
{
    public class BarberyDbContext : DbContext
    {
        public BarberyDbContext(DbContextOptions options):base(options)
        {            
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentDay> AppointmentDays { get; set; }
        public DbSet<AppointmentHour> AppointmentHours { get; set; }

    }
}
