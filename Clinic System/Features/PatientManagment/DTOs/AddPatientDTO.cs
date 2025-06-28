using System.ComponentModel.DataAnnotations;
using Clinic_managment_System.Clinic_System.Shared.Enum;
namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs
{
    public class AddPatientDTO
    {
        public int PatientId { get; set; } = 0;

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(1, ErrorMessage = "Full name cannot be empty")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 110, ErrorMessage = "Age must be between 0 and 150")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender value")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MinLength(1, ErrorMessage = "Phone number cannot be empty")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [MinLength(1, ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Marital status is required")]
        [EnumDataType(typeof(MaritalStatus), ErrorMessage = "Invalid marital status value")]
        public MaritalStatus MaritalStatus { get; set; }

        [Required(ErrorMessage = "Occupation is required")]
        [MinLength(1, ErrorMessage = "Occupation cannot be empty")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Date of visit is required")]
        public DateTime DateOfVisit { get; set; }

        [Required(ErrorMessage = "Pulse is required")]
        [MinLength(1, ErrorMessage = "Pulse cannot be empty")]
        public string Pulse { get; set; }

        [Required(ErrorMessage = "Temperature is required")]
        [MinLength(1, ErrorMessage = "Temperature cannot be empty")]
        public string Temperature { get; set; }

        [Required(ErrorMessage = "Oxygen saturation is required")]
        [MinLength(1, ErrorMessage = "Oxygen saturation cannot be empty")]
        public string OxygenSaturation { get; set; }

        [Required(ErrorMessage = "Blood sugar is required")]
        [MinLength(1, ErrorMessage = "Blood sugar cannot be empty")]
        public string BloodSugar { get; set; }

        [Required(ErrorMessage = "Hemoglobin is required")]
        [MinLength(1, ErrorMessage = "Hemoglobin cannot be empty")]
        public string Hemoglobin { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [MinLength(1, ErrorMessage = "Weight cannot be empty")]
        public string Weight { get; set; }
    }
}
