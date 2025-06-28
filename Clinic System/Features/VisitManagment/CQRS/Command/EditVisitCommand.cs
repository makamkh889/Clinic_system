using Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Command
{
    public class EditVisitCommand:IRequest<Result<EditVisitDTO>>
    {
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? ChiefComplaint { get; set; }
        public DateTime? HistoryOfPresentIllness { get; set; }
        public virtual string? RequiredInvestigations { get; set; }
        public string? DiagnosisDescription { get; set; }
        public bool IsExamined { get; set; } = false;
        public string? Pulse { get; set; } // النبض
        public string? Temperature { get; set; } // الحرارة
        public string? OxygenSaturation { get; set; } // الاوكسجين
        public string? BloodSugar { get; set; } // السكر
        public string? Hemoglobin { get; set; } // نسبة الهيموجلوبين
        public string? Weight { get; set; } // الوزن

    }
    public class EditVisitQueryHandler : IRequestHandler<EditVisitCommand, Result<EditVisitDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditVisitQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<EditVisitDTO>> Handle(EditVisitCommand request, CancellationToken cancellationToken)
        {
            var visit = unitOfWork.Visit.GetAllWithFilter(v => v.Id == request.VisitId).FirstOrDefault();

            if (visit == null)
                return Result<EditVisitDTO>.Failure("Visit not found");

            visit.DateOfVisit = request.DateOfVisit;
            visit.ChiefComplaint = request.ChiefComplaint;
            visit.HistoryOfPresentIllness = request.HistoryOfPresentIllness;
            visit.RequiredInvestigations = request.RequiredInvestigations;
            visit.DiagnosisDescription = request.DiagnosisDescription;
            visit.IsExamined = request.IsExamined;
            visit.Pulse = request.Pulse;
            visit.Temperature = request.Temperature;
            visit.OxygenSaturation = request.OxygenSaturation;
            visit.BloodSugar = request.BloodSugar;
            visit.Hemoglobin = request.Hemoglobin;
            visit.Weight = request.Weight;

            await unitOfWork.SaveChangesAsync();

            EditVisitDTO dto = visit.Map<EditVisitDTO>();
            return Result<EditVisitDTO>.Success(dto);
        }

    }
}
