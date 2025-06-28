namespace Clinic_managment_System.Clinic_System.Features.AccountManagment.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool RemeberMe { get; set; }
    }
}
