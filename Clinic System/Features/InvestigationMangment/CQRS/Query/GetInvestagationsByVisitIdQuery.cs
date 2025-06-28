using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.DTO;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Query
{
    public class GetInvestagationsByVisitIdQuery : IRequest<Result<List<GetInvestgationDTO>>>
    {
        public int id { get; set; }
    }
    public class GetInvestagationsByVisitIdQueryHandler : IRequestHandler<GetInvestagationsByVisitIdQuery, Result<List<GetInvestgationDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetInvestagationsByVisitIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetInvestgationDTO>>> Handle(GetInvestagationsByVisitIdQuery request, CancellationToken cancellationToken)
        {
            List<Investigation> investigations = unitOfWork.Investigation.GetAllWithFilter(i => i.VisitId == request.id).ToList();
            List<GetInvestgationDTO> getInvestgationDTOs = investigations.Map<List<GetInvestgationDTO>>();
            return Result<List<GetInvestgationDTO>>.Success(getInvestgationDTOs);
        }
    }

}


