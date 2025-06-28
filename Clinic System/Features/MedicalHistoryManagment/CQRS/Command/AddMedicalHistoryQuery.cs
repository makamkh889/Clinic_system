using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.CQRS.Command
{
    public class AddMedicalHistoryQuery:IRequest<Result<string>>
    {
        public int PatientId { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? SurgicalHistories { get; set; }
        public string? FamilyHistories { get; set; }
        public string? Allergies { get; set; }
        public string? SocialHistories { get; set; }
    }
    public class AddMedicalHistoryQueryHandler : IRequestHandler<AddMedicalHistoryQuery, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddMedicalHistoryQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            var medical=unitOfWork.MedicalHistory.GetAllWithFilter(m => m.PatientId == request.PatientId).FirstOrDefault();
            if(medical != null)
            {
                return Result<string>.Failure("Medical history already exists for this patient.");
            }
            MedicalHistory NewmedicalHistory = request.Map<MedicalHistory>();
            await unitOfWork.MedicalHistory.AddAsync(NewmedicalHistory);
            await unitOfWork.SaveChangesAsync();
            return Result<string>.Success("Medical history has been successfully added.");
        }
    }
}
