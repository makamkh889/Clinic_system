using Clinic_managment_System.Clinic_System.Features.MedicineMangment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Query
{
    public class GetMedicinByNameQuery : IRequest<Result<List<GetMedicinDTO>>>
    {
        public string MedicinName{get;set;}
    }
    public class GetMedicinByNameQueryHandler : IRequestHandler<GetMedicinByNameQuery, Result<List<GetMedicinDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetMedicinByNameQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetMedicinDTO>>> Handle(GetMedicinByNameQuery request, CancellationToken cancellationToken)
        {
            List<Medicine> medicine = unitOfWork.Medicine.GetAllWithFilter(m => m.TradeName.Contains(request.MedicinName)).ToList();
            List<GetMedicinDTO> getMedicinDTOs = medicine.Map<List<GetMedicinDTO>>();
            return Result<List<GetMedicinDTO>>.Success(getMedicinDTOs);
        }
    }

}
