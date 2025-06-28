using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.DTO;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.CQRS.Query
{
    public class GetTreatmentByVisitIdQuery:IRequest<Result<List<GetTreatmentDTO>>>
    {
        public int id { get; set; }
    }
    public class GetTreatmentByVisitIdQueryHandler : IRequestHandler<GetTreatmentByVisitIdQuery, Result<List<GetTreatmentDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetTreatmentByVisitIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetTreatmentDTO>>> Handle(GetTreatmentByVisitIdQuery request, CancellationToken cancellationToken)
        {
            var treatments = unitOfWork.Treatment.GetAllWithFilter(t => t.VisitId == request.id).ToList();
            var GetTreatmentDTO = treatments.Select(t =>
            {
                 var medicin = unitOfWork.Medicine
                 .GetAllWithFilter(m => m.Id == t.medicineId)
                 .Select(m => m.TradeName).FirstOrDefault();

                 return new GetTreatmentDTO
                 {
                     Dose = t.Dose,
                     Frequency = t.Frequency,
                     Duration = t.Duration,
                     medicineId=t.medicineId,
                     Name = medicin ?? "",
                     Notes = t.Notes,
                     VisitId = t.VisitId,
                 };
            });
            return Result<List<GetTreatmentDTO>>.Success(GetTreatmentDTO.ToList());
        }
    }
}
