using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.Models
{
    public class MedicalHistory:BaseModel
    {
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }

        public string? ChronicDiseases { get; set; }
        public ICollection<DrugHistory> DrugHistories { get; set; }
        public string? SurgicalHistories { get; set; }
        public string? FamilyHistories { get; set; }
        public string? Allergies { get; set; }
        public string? SocialHistories { get; set; }

    }
}
