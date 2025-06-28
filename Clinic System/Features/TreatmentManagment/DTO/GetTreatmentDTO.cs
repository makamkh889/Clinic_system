namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.DTO
{
    public class GetTreatmentDTO
    {
        public int VisitId { get; set; }
        public int? FollowUpId { get; set; }
        public int medicineId { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Notes { get; set; }
    }
}
