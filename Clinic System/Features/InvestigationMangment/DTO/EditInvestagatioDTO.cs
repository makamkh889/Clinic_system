using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.DTO
{
    public class EditInvestagatioDTO
    {
        public int VisitId { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
    }
}
