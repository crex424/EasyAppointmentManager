using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyAppointmentManager.Models;

namespace EasyAppointmentManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EasyAppointmentManager.Models.Specialty>? Specialty { get; set; }
        public DbSet<EasyAppointmentManager.Models.Customer>? Customer { get; set; }
        public DbSet<EasyAppointmentManager.Models.Clinic>? Clinic { get; set; }
        public DbSet<EasyAppointmentManager.Models.Doctor>? Doctor { get; set; }
    }
}