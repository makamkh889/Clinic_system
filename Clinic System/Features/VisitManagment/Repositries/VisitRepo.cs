using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment
{
    public class VisitRepo : GenericRepository<Visit>, IVisitRepo
    {
        private readonly ClinicDbContext _applicationDBContext;
        public VisitRepo(ClinicDbContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

    }
}
