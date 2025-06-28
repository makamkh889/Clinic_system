using Azure.Core;
using Clinic_managment_System.Clinic_System.Shared.Enum;
using InventoryManagmentSystem.Shared.UnitOfWorks;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands
{
    public class AddPatientCommand:IRequest<Result<bool>>
    {
        [Required]
        public string FullName { get; set; }
        public int? Age { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string? Occupation { get; set; }
    }
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, Result<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddPatientCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<bool>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Patient patient = new()
                {
                    FullName = request.FullName,
                    Age = request.Age,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    MaritalStatus = request.MaritalStatus,
                    Occupation = request.Occupation
                };
                unitOfWork.Patient.AddAsync(patient);
                return Result<bool>.Success(true);
            }
            catch
            {
                return Result<bool>.Success(false);
            }

        }
    }
}
