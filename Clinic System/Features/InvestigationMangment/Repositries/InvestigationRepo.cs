using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Features.PatientManagment;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.Repositries
{
    public class InvestigationRepo : GenericRepository<Investigation>, IInvestigationRepo
    {
        private readonly ClinicDbContext _applicationDBContext;
        public InvestigationRepo(ClinicDbContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

    }
}
