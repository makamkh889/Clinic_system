using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.Models
{
    public class Visit:BaseModel
    {
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? ChiefComplaint { get; set; }
        public DateTime? HistoryOfPresentIllness { get; set; }
        public virtual string? RequiredInvestigations { get; set; } 
        public string? DiagnosisDescription { get; set; }

        public bool IsExamined { get; set; } = false;

        public string? Pulse { get; set; } // النبض
        public string? Temperature { get; set; } // الحرارة
        public string? OxygenSaturation { get; set; } // الاوكسجين
        public string? BloodSugar { get; set; } // السكر
        public string? Hemoglobin { get; set; } // نسبة الهيموجلوبين
        public string? Weight { get; set; } // الوزن

        public virtual ICollection<Investigation>? Investigations { get; set; }
        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }
        public virtual ICollection<FollowUp> FollowUp { get; set; }
    }
}
