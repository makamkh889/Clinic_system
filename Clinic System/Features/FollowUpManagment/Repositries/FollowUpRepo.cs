using clinic.Infrastructure.Data;
using Clinic_managment_System.Clinic_System.Shared.Repository;

namespace Clinic_managment_System.Clinic_System.Features.FollowUpManagment
{
    public class FollowUpRepo : GenericRepository<FollowUp>, IFollowUpRepo
    {
        private readonly ClinicDbContext _applicationDBContext;
        public FollowUpRepo(ClinicDbContext applicationDBContext):base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

    }
}
