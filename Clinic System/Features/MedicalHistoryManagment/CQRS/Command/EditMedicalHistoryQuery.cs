using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.CQRS.Command
{
    public class EditMedicalHistoryQuery : IRequest<Result<EditMedicalHistoryDTO>>
    {
        public int PatientId { get; set; }
        public string? ChronicDiseases { get; set; }
        public string? SurgicalHistories { get; set; }
        public string? FamilyHistories { get; set; }
        public string? Allergies { get; set; }
        public string? SocialHistories { get; set; }
    }
    public class EditMedicalHistoryQueryHandler : IRequestHandler<EditMedicalHistoryQuery, Result<EditMedicalHistoryDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditMedicalHistoryQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<EditMedicalHistoryDTO>> Handle(EditMedicalHistoryQuery request, CancellationToken cancellationToken)
        {
            var medical = unitOfWork.MedicalHistory.GetAllWithFilter(m => m.PatientId == request.PatientId).FirstOrDefault();
            if (medical == null)
            {
                return Result<EditMedicalHistoryDTO>.Failure("Medical history not exists for this patient.");
            }
            medical.SocialHistories = request.SocialHistories;
            medical.SurgicalHistories = request.SurgicalHistories;
            medical.FamilyHistories = request.FamilyHistories;
            medical.ChronicDiseases = request.ChronicDiseases;
            medical.Allergies = request.Allergies;
            await unitOfWork.SaveChangesAsync();
            EditMedicalHistoryDTO medicalHistoryDTO = medical.Map<EditMedicalHistoryDTO>();
            return Result<EditMedicalHistoryDTO>.Success(medicalHistoryDTO);
        }
    }
}
