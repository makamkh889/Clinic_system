using Clinic_managment_System.Clinic_System.Features.MedicineMangment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Command
{
    public class AddMedicineQuery:IRequest<Result<string>>
    {
        public string MedicineCode { get; set; }
        public string TradeName { get; set; }
        public string Composition { get; set; }
        public string Concentration { get; set; }
        public string Unit { get; set; }
        public string PharmaceuticalForm { get; set; }
        public string Company { get; set; }
        public string RegistrationNumber { get; set; }
        public string MedicineType { get; set; }
    }
    public class AddMedicineQueryHandler : IRequestHandler<AddMedicineQuery, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddMedicineQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddMedicineQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Medicine medicine = request.Map<Medicine>();
                await unitOfWork.Medicine.AddAsync(medicine);
                await unitOfWork.SaveChangesAsync();
                return Result<string>.Success("Done");
            }
            catch
            {
                return Result<string>.Failure("Error on Added");
            }
        }
    }
}
