
using Clinic_managment_System.Clinic_System.Shared.Enum;
using System.ComponentModel.DataAnnotations;
namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.Models
{
    public class Patient:BaseModel
    {
        [Required] 
        public string FullName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string? Occupation { get; set; }
        public virtual MedicalHistory? History { get; set; }
        public virtual ICollection<Visit>? Visits { get; set; }

    }
}
