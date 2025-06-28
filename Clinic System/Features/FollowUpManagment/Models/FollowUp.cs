using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.FollowUpManagment.Models
{

    public class FollowUp:BaseModel
    { 
        public DateTime FollowUpDate { get; set; } = DateTime.Now;
        public string Notes { get; set; }
        public int VisitId { get; set; }

        [ForeignKey(nameof(VisitId))]
        public Visit Visit { get; set; }
    }
}
