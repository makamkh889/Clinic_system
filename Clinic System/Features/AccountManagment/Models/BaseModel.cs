using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic_managment_System.Clinic_System.Features.AccountManagement.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public bool IsDelete { get; set; } = false;
    }
}
