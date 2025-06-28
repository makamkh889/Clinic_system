using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Models
{
    public class Medicine:BaseModel
    {
        public string MedicineCode { get; set; }
        public string TradeName { get; set; }
        public string Composition { get; set; }
        public string Concentration { get; set; }
        public string Unit { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string Company { get; set; }
        public string RegistrationNumber { get; set; }
        public string MedicineType { get; set; }

    }
}
