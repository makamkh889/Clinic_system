using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.CQRS.Query
{
    public class GetMedicalHistoryByPatientIdQuery : IRequest<Result<GetMedicalHistoryDTO>>
    {
        public int id { get; set; }
    }
    public class GetMedicalHistoryByPatientIdQueryHandler : IRequestHandler<GetMedicalHistoryByPatientIdQuery, Result<GetMedicalHistoryDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetMedicalHistoryByPatientIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GetMedicalHistoryDTO>> Handle(GetMedicalHistoryByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var medical=unitOfWork.MedicalHistory.GetAllWithFilter(m => m.PatientId == request.id).FirstOrDefault();

            if (medical == null)
            {
                return Result<GetMedicalHistoryDTO>.Failure("No Medical History For This Patient");
            }
            GetMedicalHistoryDTO getMedicalHistoryDTO = medical.Map<GetMedicalHistoryDTO>();
            return Result<GetMedicalHistoryDTO>.Success(getMedicalHistoryDTO);
        }
    }
}
