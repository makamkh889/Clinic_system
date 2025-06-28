using Clinic_managment_System.Clinic_System.Shared.Enum;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands
{
    public class EditPatientCommand : IRequest<Result<bool>>
    {
        public int PatientId { get; set; }

        [Required]
        public string FullName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string? Occupation { get; set; }
    }
    public class EditPatientCommandHandler : IRequestHandler<EditPatientCommand, Result<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        public EditPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Patient patient = unitOfWork.Patient.GetAllWithFilter(p => p.Id == request.PatientId).FirstOrDefault();
                if (patient == null)
                {
                    return Result<bool>.Failure("Patient Not found");
                }

                patient.FullName = request.FullName;
                patient.Age = request.Age;
                patient.Gender = request.Gender;
                patient.PhoneNumber = request.PhoneNumber;
                patient.Address = request.Address;
                patient.MaritalStatus = request.MaritalStatus;
                patient.Occupation = request.Occupation;

                await unitOfWork.SaveChangesAsync(); 
                return Result<bool>.Success(true);
            }
            catch
            {
                return Result<bool>.Failure("An error occurred while updating the patient.");
            }
        }

    }
}

