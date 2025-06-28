using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.Models;
using Clinic_managment_System.Clinic_System.Shared.Enum;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Orchestrators
{
    public class AddPatientOrchestrat:IRequest<Result<string>>
    {
        public int PatientId { get; set; }
        [Required]
        public string FullName { get; set; }
        public int? Age { get; set; }

        [Required]
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [Required]
        public MaritalStatus MaritalStatus { get; set; }
        public string? Occupation { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string? Pulse { get; set; }  // النبض
        public string? Temperature { get; set; }   // الحرارة
        public string? OxygenSaturation { get; set; }   // الاوكسجين
        public string? BloodSugar { get; set; }  // السكر
        public string? Hemoglobin { get; set; }  // نسبة الهيموجلوبين
        public string? Weight { get; set; }  // الوزن
    }
    public class AddPatientOrchestratHandler : IRequestHandler<AddPatientOrchestrat, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public AddPatientOrchestratHandler(IMediator mediator, IUnitOfWork unitOfWork)
        {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<string>> Handle(AddPatientOrchestrat request, CancellationToken cancellationToken)
        {
            try
            {
                Result<bool> resultAddPatient = await mediator.Send(new AddPatientCommand()
                {

                    FullName = request.FullName,
                    Age = request.Age,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    MaritalStatus = request.MaritalStatus,
                    Occupation = request.Occupation
                });

                if (!resultAddPatient.Data)
                {
                    return Result<string>.Failure("Patient Not Added");
                }
                await unitOfWork.SaveChangesAsync();

                int PatientId = unitOfWork.Patient.GetAllWithFilter(p=>
                    p.FullName == request.FullName&&
                    p.PhoneNumber == request.PhoneNumber).Select(p=>p.Id).FirstOrDefault();

                Result<bool> resultAddVisit = await mediator.Send(new AddVisitCommand()
                {
                    PatientId = PatientId,
                    DateOfVisit = request.DateOfVisit,
                    Pulse = request.Pulse,
                    Temperature = request.Temperature,
                    OxygenSaturation = request.OxygenSaturation,
                    BloodSugar = request.BloodSugar,
                    Hemoglobin = request.Hemoglobin,
                    Weight = request.Weight
                });

                if (!resultAddVisit.Data)
                {
                    return Result<string>.Failure("Visit Not Added");
                }
                await unitOfWork.SaveChangesAsync();
                return Result<string>.Success("Done");

            }
            catch
            {
               return Result<string>.Failure("Something error happen");
            }
        }
    }
}
