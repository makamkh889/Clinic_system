using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Models
{
    public class TreatmentPlan:BaseModel
    {
        public int VisitId { get; set; }
        [ForeignKey(nameof(VisitId))]
        public virtual Visit Visit { get; set; }

        public int medicineId { get; set; }
        [ForeignKey(nameof(medicineId))]
        public Medicine medicine { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Notes { get; set; }
    }
}
