using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using Mapster;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.VisitModelMapping
{
    public class VisitMapping
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Visit, GetVisitDTO>.NewConfig();
            TypeAdapterConfig<Visit, EditVisitDTO>.NewConfig();

        }

    }
}
