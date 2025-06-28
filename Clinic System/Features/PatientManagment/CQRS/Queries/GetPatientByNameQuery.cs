using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using InventoryManagmentSystem.Shared.MapperServices;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries
{
    public class GetPatientByNameQuery:IRequest<Result<GetPatientDetailsDTO>>
    {
        public string FullName { get; set; }
    }
    public class GetPatientQueryHandler : IRequestHandler<GetPatientByNameQuery, Result<GetPatientDetailsDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetPatientQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<GetPatientDetailsDTO>> Handle(GetPatientByNameQuery request, CancellationToken cancellationToken)
        {
            var patient = unitOfWork.Patient.GetAllWithFilter(p => p.FullName == null || p.FullName.Contains(request.FullName))
                .Select(p => new
                {
                    PatientId=p.Id,p.FullName,p.Age,p.Gender,
                    p.PhoneNumber,p.Address,p.MaritalStatus,p.Occupation
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
