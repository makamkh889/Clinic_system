using Azure;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Shared.ResultsOfAPI;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries
{
    public class GetAllPatientsQuery : IRequest<Result<List<GetAllPatientDTO>>>
    {
        public int Take { get; set; }
    }
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, Result<List<GetAllPatientDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllPatientsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<List<GetAllPatientDTO>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            var currentPage = request.Take < 1 ? 1 : request.Take;
            var patients = unitOfWork.Patient.GetAllWithFilter(p=>p.IsDelete==false).Skip((currentPage-1)*8).Take(8).ToList();

            if (patients == null || !patients.Any())
            {
                return Result<List<GetAllPatientDTO>>.Failure("No patients found.");
            }

            var patientDTOs = patients.Select(patient =>
            {
                var visits =unitOfWork.Visit.GetAllWithFilter(v => v.PatientId == patient.Id )
                    .Select(v => new
                    {
                        v.Id,
                        v.DateOfVisit,
                        v.IsExamined
                    }).FirstOrDefault();

                if (visits == null)
                {
                    return null;
                }
                return new GetAllPatientDTO
                {
                    PatientId = patient.Id,
                    FullName = patient.FullName,
                    IsExamined=visits.IsExamined,
                    DateOfVisit = visits.DateOfVisit,
                    CountOfFollowUp =unitOfWork.FollowUp.GetAllWithFilter(f => f.VisitId == visits.Id).Count(),
                };
            }).Where(dto => dto != null).ToList();

            //if(patientDTOs==null|| !patientDTOs.Any())
            //{
            //    return Result<List<GetAllPatientDTO>>.Success(patientDTOs);
            //}
            return Result<List<GetAllPatientDTO>>.Success(patientDTOs);
        }

    }
}
