using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.DTO
{
    public class EditMedicalHistoryDTO
    {

        public int PatientId { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? SurgicalHistories { get; set; }
        public string? FamilyHistories { get; set; }
        public string? Allergies { get; set; }
        public string? SocialHistories { get; set; }
    }
}
