namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO
{
    public class GetVisitDTO
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
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
    }
}
