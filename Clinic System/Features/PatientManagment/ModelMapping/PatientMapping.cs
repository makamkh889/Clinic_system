using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Mapster;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment
{
    public class PatientMapping
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Patient, GetPatientDetailsDTO>.NewConfig();
                

        } 

    }
}
