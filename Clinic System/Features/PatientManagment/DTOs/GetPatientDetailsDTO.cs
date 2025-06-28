using Clinic_managment_System.Clinic_System.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs
{
    public class GetPatientDetailsDTO
    {
        public int PatientId { get; set; }
        [Required]
        public string FullName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool IsExamined { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public string? Occupation { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? Pulse { get; set; } // النبض
        public string? Temperature { get; set; } // الحرارة
        public string? OxygenSaturation { get; set; } // الاوكسجين
        public string? BloodSugar { get; set; } // السكر
        public string? Hemoglobin { get; set; } // نسبة الهيموجلوبين
        public string? Weight { get; set; } // الوزن

    }
}
