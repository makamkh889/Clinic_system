using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Query
{
    public class GetVisitByIdQuery: IRequest<Result<GetVisitDTO>>
    {
        public int Id { get; set; }
    }
    public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, Result<GetVisitDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetVisitByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GetVisitDTO>> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var visit = unitOfWork.Visit.GetAllWithFilter(v => v.Id == request.Id).FirstOrDefault();

            if (visit == null)
                return Result<GetVisitDTO>.Failure("Something Error");

            GetVisitDTO visitDTO = visit.Map<GetVisitDTO>();
            visitDTO.VisitId = visit.Id;
           
            return Result<GetVisitDTO>.Success(visitDTO);
        }
    }
}
