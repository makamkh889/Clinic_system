using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Query
{
    public class GetVisitByPatientIdQuery : IRequest<Result<GetVisitDTO>>
    {
        public int Id { get; set; }
    }
    public class GetVisitByPatientIdQueryHandler : IRequestHandler<GetVisitByPatientIdQuery, Result<GetVisitDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetVisitByPatientIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GetVisitDTO>> Handle(GetVisitByPatientIdQuery request, CancellationToken cancellationToken)
        {
            var visit = unitOfWork.Visit.GetAllWithFilter(v => v.PatientId == request.Id).FirstOrDefault();

            if (visit == null)
                return Result<GetVisitDTO>.Failure("Something Error");

            GetVisitDTO visitDTO = visit.Map<GetVisitDTO>();
            visitDTO.VisitId = visit.Id;

            return Result<GetVisitDTO>.Success(visitDTO);
        }
    }
}
