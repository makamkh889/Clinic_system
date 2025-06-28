using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clinic_managment_System.Clinic_System.Features.AccountManagment.CQRS.queries
{
    public class LogOutQuery:IRequest<Unit>
    {
    }
    public class LogOutQueryHandler : IRequestHandler<LogOutQuery, Unit>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LogOutQueryHandler(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<Unit> Handle(LogOutQuery request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();
            return Unit.Value;
        }

    }
}
