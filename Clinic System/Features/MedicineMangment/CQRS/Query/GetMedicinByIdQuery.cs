using Clinic_managment_System.Clinic_System.Features.MedicineMangment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Query
{
    public class GetMedicinByIdQuery : IRequest<Result<List<GetMedicinDTO>>>
    {
        public string MedicinCode { get; set; }
    }
    public class GetMedicinByIdQueryHandler : IRequestHandler<GetMedicinByIdQuery, Result<List<GetMedicinDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetMedicinByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetMedicinDTO>>> Handle(GetMedicinByIdQuery request, CancellationToken cancellationToken)
        {
            List<Medicine> medicine = unitOfWork.Medicine.GetAllWithFilter(m => m.MedicineCode==request.MedicinCode).ToList();
            List<GetMedicinDTO> getMedicinDTOs = medicine.Map<List<GetMedicinDTO>>();
            return Result<List<GetMedicinDTO>>.Success(getMedicinDTOs);
        }
    }

}

