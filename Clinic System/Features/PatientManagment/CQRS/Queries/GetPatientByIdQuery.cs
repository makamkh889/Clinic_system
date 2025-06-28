using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.Models;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries
{
    public class GetPatientByIdQuery : IRequest<Result<GetPatientDetailsDTO>>
    {
        public int Id { get; set; }
    }
    public class GetPatientIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Result<GetPatientDetailsDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPatientIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GetPatientDetailsDTO>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = unitOfWork.Patient.GetAllWithFilter(p => p.Id == request.Id)
                 .Select(p => new
                 {
                     PatientId=p.Id,
                     p.FullName,
                     p.Age,
                     p.Gender,
                     p.PhoneNumber,
                     p.Address,
                     p.MaritalStatus,
                     p.Occupation
                 }).FirstOrDefault();

            if (patient == null)
            {
                return Result<GetPatientDetailsDTO>.Failure("Patient Not Found");
            }
            var visit = unitOfWork.Visit.GetAllWithFilter(v => v.PatientId == patient.PatientId)
                .Select(v => new
                {
                    v.IsExamined,
                    v.DateOfVisit,
                    v.Pulse,
                    v.Temperature,
                    v.OxygenSaturation,
                    v.BloodSugar,
                    v.Hemoglobin,
                    v.Weight
                });
            GetPatientDetailsDTO getPatient = patient.Map<GetPatientDetailsDTO>();
            var visitData = visit.FirstOrDefault();
            if (visitData != null)
            {
                getPatient.IsExamined = visitData.IsExamined;
                getPatient.DateOfVisit = visitData.DateOfVisit;
                getPatient.Pulse = visitData.Pulse;
                getPatient.Temperature = visitData.Temperature;
                getPatient.OxygenSaturation = visitData.OxygenSaturation;
                getPatient.BloodSugar = visitData.BloodSugar;
                getPatient.Hemoglobin = visitData.Hemoglobin;
                getPatient.Weight = visitData.Weight;
            }

            return Result<GetPatientDetailsDTO>.Success(getPatient);
        }
    }
}
