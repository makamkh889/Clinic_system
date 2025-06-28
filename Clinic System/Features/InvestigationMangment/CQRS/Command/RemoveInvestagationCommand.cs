using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Command
{
    public class RemoveInvestagationCommand:IRequest<Result<string>>
    {
        public int id { get; set; }
    }
    public class RemoveInvestagationCommandHandler : IRequestHandler<RemoveInvestagationCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveInvestagationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(RemoveInvestagationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool s = await unitOfWork.Investigation.Delete(i => i.Id == request.id);

                if (s)
                {
                    await unitOfWork.SaveChangesAsync();
                    return Result<string>.Success("Removed successful");
                }
                else
                    return Result<string>.Failure("someerror happen");

            }
            catch
            {
                return Result<string>.Failure("someerror happen");
            }
        }
    }
}
