using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.CQRS.Command
{
    public class EditTreatmentQuery : IRequest<Result<EditTreatmentPlanDTO>>
    {
        public int VisitId { get; set; }
        public int? FollowUpId { get; set; }
        public int medicineId { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Notes { get; set; }
    }
    public class EditTreatmentQueryHandler : IRequestHandler<EditTreatmentQuery, Result<EditTreatmentPlanDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditTreatmentQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<EditTreatmentPlanDTO>> Handle(EditTreatmentQuery request, CancellationToken cancellationToken)
        {
            var treatment = unitOfWork.Treatment.GetAllWithFilter(t => t.VisitId == request.VisitId&& t.medicineId==request.medicineId).FirstOrDefault();
            if (treatment == null)
            {
                return Result<EditTreatmentPlanDTO>.Failure("Treatment Plan not found");
            }
            treatment.Dose = request.Dose;
            treatment.Frequency = request.Frequency;
            treatment.Duration = request.Duration;
            treatment.Notes = request.Notes;
            await unitOfWork.SaveChangesAsync();
            var treatDTO = treatment.Map<EditTreatmentPlanDTO>();
            return Result<EditTreatmentPlanDTO>.Success(treatDTO);
        }
    }
}

