using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.CQRS.Command
{
    public class AddTreatmentQuery:IRequest<Result<string>>
    {
        public int VisitId { get; set; }
        public int? FollowUpId { get; set; }
        public int medicineId { get; set; }
        public string Dose { get; set; }
        public string Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Notes { get; set; }
    }
    public class AddTreatmentQueryHandler : IRequestHandler<AddTreatmentQuery, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddTreatmentQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddTreatmentQuery request, CancellationToken cancellationToken)
        {
            TreatmentPlan treatment = request.Map<TreatmentPlan>();
             await unitOfWork.Treatment.AddAsync(treatment);
            await unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Done");
        }
    }
}
