using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Command
{
    public class AddInvestagationCommand : IRequest<Result<string>>
    {

        public int VisitId { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
    }
    public class AddInvestagationCommandHandler : IRequestHandler<AddInvestagationCommand, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddInvestagationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddInvestagationCommand request, CancellationToken cancellationToken)
        {
            Investigation investigation = request.Map<Investigation>();

            await unitOfWork.Investigation.AddAsync(investigation);
            await unitOfWork.SaveChangesAsync();

            return Result<string>.Success("Done");
        }

    }
}

