using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.Repositries
{
    public class MedicalHistoryRepo : GenericRepository<MedicalHistory>, IMedicalHistoryRepo
    {
        ClinicDbContext applicationDBContext;
        public MedicalHistoryRepo(ClinicDbContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
    }
}
