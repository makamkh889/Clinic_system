using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.Models
{
    public class Investigation:BaseModel
    {
        public int VisitId { get; set; }

        [ForeignKey(nameof(VisitId))]
        public virtual Visit Visit { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
    }
}
