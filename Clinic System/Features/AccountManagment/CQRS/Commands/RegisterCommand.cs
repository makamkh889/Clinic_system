using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Clinic_managment_System.Clinic_System.Features.AccountManagment.CQRS.Commands
{
    public class RegisterCommand:IRequest<Result<string>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<string>>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RegisterCommandHandler(RoleManager<IdentityRole> roleManager,SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            StringBuilder error = new();
            bool isFirstUser = !await userManager.Users.AnyAsync();
                if (await userManager.Users.AnyAsync(u => u.Email == request.Email))
                {
                    return Result<string>.Failure("Email is already registered");
                }

                if (await userManager.Users.AnyAsync(u => u.UserName == request.UserName))
                {
                    return Result<string>.Failure("Username is already taken");
                }

                ApplicationUser applciationUser = new()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };
                IdentityResult identityResult = await userManager.CreateAsync(applciationUser, request.Password);
            if (identityResult.Succeeded)
            {
                if (isFirstUser)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                    await userManager.AddToRoleAsync(applciationUser, "Admin");
                }
                else
                {
                    if (!await roleManager.RoleExistsAsync("User"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("User"));
                    }
                    await userManager.AddToRoleAsync(applciationUser, "User");
                }
                return Result<string>.Success("User Registeration Successfully");
            }
            else
            {
                foreach (IdentityError identityError in identityResult.Errors)
                {
                    error.Append(identityError.Description);
                }
            }
            
            return Result<string>.Failure(error.ToString());
        }
    }
}
