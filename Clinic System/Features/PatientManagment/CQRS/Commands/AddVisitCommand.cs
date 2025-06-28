using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands
{
    public class AddVisitCommand:IRequest<Result<bool>>
    {
        public int PatientId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? Pulse { get; set; } // النبض
        public string? Temperature { get; set; } // الحرارة
        public string? OxygenSaturation { get; set; } // الاوكسجين
        public string? BloodSugar { get; set; } // السكر
        public string? Hemoglobin { get; set; } // نسبة الهيموجلوبين
        public string? Weight { get; set; } // الوزن
    }
    public class AddVisitCommandHandler : IRequestHandler<AddVisitCommand, Result<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddVisitCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(AddVisitCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Visit visit = new()
                {
                    PatientId = request.PatientId,
                    DateOfVisit = request.DateOfVisit,
                    Pulse = request.Pulse,
                    Temperature = request.Temperature,
                    OxygenSaturation = request.OxygenSaturation,
                    BloodSugar = request.BloodSugar,
                    Hemoglobin = request.Hemoglobin,
                    Weight = request.Weight
                };
                await unitOfWork.Visit.AddAsync(visit);
                return Result<bool>.Success(true);
            }
            catch
            {
                return Result<bool>.Success(false);
            }
        }
    }
}
