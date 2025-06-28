using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.DTO;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Command
{
    public class EditInvestagationCommand : IRequest<Result<EditInvestagatioDTO>>
    {

        public int VisitId { get; set; }
        public int InvestagationId { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
    }
    public class EditInvestagationCommandHandler : IRequestHandler<EditInvestagationCommand, Result<EditInvestagatioDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditInvestagationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<EditInvestagatioDTO>> Handle(EditInvestagationCommand request, CancellationToken cancellationToken)
        {
            var investigation = unitOfWork.Investigation.GetAllWithFilter(i => i.Id == request.InvestagationId).FirstOrDefault();

            if (investigation == null)
                return Result<EditInvestagatioDTO>.Failure("Investigation not found");

            investigation.TestName = request.TestName;
            investigation.Result = request.Result;

            await unitOfWork.SaveChangesAsync();

            EditInvestagatioDTO dto = investigation.Map<EditInvestagatioDTO>();
            return Result<EditInvestagatioDTO>.Success(dto);
        }

    }
}
