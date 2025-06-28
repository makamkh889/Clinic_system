using Clinic_managment_System.Clinic_System.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs
{
    public class EditPatientDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender value")]
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [EnumDataType(typeof(MaritalStatus), ErrorMessage = "Invalid marital status value")]
        public MaritalStatus MaritalStatus { get; set; }
        public string Occupation { get; set; }
    }

}

