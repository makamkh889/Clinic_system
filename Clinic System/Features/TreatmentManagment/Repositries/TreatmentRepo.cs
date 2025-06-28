using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Repositries
{
    public class TreatmentRepo : GenericRepository<TreatmentPlan>, ITreatmentRepo
    {
        private readonly ClinicDbContext applicationDBContext;
        public TreatmentRepo(ClinicDbContext applicationDBContext) : base(applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
    }
}
