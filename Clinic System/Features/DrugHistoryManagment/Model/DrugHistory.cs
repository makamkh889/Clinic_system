using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.Models
{
    public class DrugHistory:BaseModel
    {
        public int medicineId { get; set; }

        [ForeignKey(nameof(medicineId))]
        public Medicine medicine { get; set; }
        public string Dose { get; set; }
        public int MedicalHistoryId { get; set; }

        [ForeignKey(nameof(MedicalHistoryId))]
        public virtual MedicalHistory MedicalHistory { get; set; }
    }
}
