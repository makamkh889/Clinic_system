using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic_managment_System.Clinic_System.Features.AccountManagment.CQRS.queries
{
    public class LoginQuery:IRequest<Result<string>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RemeberMe { get; set; }
    }
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<string>>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public LoginQueryHandler(IConfiguration configuration,SignInManager<ApplicationUser>signInManager,UserManager<ApplicationUser>userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
                ApplicationUser? user = await userManager.FindByNameAsync(request.UserName);

                if (user is null)
                {
                    return Result<string>.Failure("User not found");
                }

                SignInResult signInResult = await signInManager.PasswordSignInAsync(user.UserName, request.Password, isPersistent: request.RemeberMe, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    string Token = await GenerateToken(user);
                    return Result<string>.Success(Token);
                }
                else
                {
                    return Result<string>.Failure("User name or password is not valid");
                }

            //return Result<string>.Failure("User Log In Credintial Is Not Valid");

        }
        public async Task<string> GenerateToken(ApplicationUser user)
        {
            string jti = Guid.NewGuid().ToString();
            var userRoles = await userManager.GetRolesAsync(user);


            List<Claim> claim = new List<Claim>();
            claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claim.Add(new Claim(ClaimTypes.Name, user.UserName));
            claim.Add(new Claim(JwtRegisteredClaimNames.Jti, jti));
            if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            SymmetricSecurityKey signinKey =
                new(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));

            SigningCredentials signingCredentials =
                new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken myToken = new JwtSecurityToken(
                issuer: configuration["JWT:Iss"],
                audience: configuration["JWT:Aud"],
                expires: DateTime.Now.AddDays(10),
                claims: claim,
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(myToken);
        }

    }
}
