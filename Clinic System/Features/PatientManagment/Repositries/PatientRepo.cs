using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment
{
    public class PatientRepo: GenericRepository<Patient>, IPatientRepo
    {
        private readonly ClinicDbContext _applicationDBContext;
        public PatientRepo(ClinicDbContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

    }
}
