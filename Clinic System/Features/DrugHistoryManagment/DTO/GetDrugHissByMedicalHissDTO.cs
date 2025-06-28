using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.DrugHistoryManagment.DTO
{
    public class GetDrugHissByMedicalHissDTO
    {
        public int medicineId { get; set; }
        //public string MedicineName
        public string Dose { get; set; }
        public int MedicalHistoryId { get; set; }

        [ForeignKey(nameof(MedicalHistoryId))]
        public virtual MedicalHistory MedicalHistory { get; set; }
    }
}
