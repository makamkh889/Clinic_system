using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.DrugHistoryManagment.Repositries
{
    public class DrugHistoryRepo:GenericRepository<DrugHistory>,IDrugHistoryRepo
    {
        private readonly ClinicDbContext _applicationDBContext;
        public DrugHistoryRepo(ClinicDbContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
    }
}
