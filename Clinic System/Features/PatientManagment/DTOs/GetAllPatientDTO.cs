using Clinic_managment_System.Clinic_System.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs
{
    public class GetAllPatientDTO
    {
        public int PatientId { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime DateOfVisit { get; set; }
        public bool? IsExamined { get; set; } 
        public int? CountOfFollowUp { get; set; } 

    }
}

