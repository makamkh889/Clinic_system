using Clinic_managment_System.Clinic_System.Features.AccountManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace clinic.Infrastructure.Data
{
    public class ClinicDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DrugHistory> DrugHistorys { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<Investigation> Investigations { get; set; }
        public DbSet<MedicalHistory> MedicalHistorys { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
        }
    }
}
