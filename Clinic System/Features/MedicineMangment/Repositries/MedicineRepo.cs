using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.MedicineMangment.Repositries
{
    public class MedicineRepo: GenericRepository<Medicine>,IMedicineRepo
    {
        private readonly ClinicDbContext clinicDbContext;
        public MedicineRepo(ClinicDbContext clinicDbContext):base(clinicDbContext)
        {
            this.clinicDbContext = clinicDbContext;
        }
    }
}
