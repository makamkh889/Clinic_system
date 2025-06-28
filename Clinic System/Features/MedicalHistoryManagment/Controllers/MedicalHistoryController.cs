using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.MedicalHistoryManagment
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public MedicalHistoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetMedicalHistoryByPatientId(int id)
        {
            var result = await mediator.Send(new GetMedicalHistoryByPatientIdQuery { id = id });
            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        } 
        [HttpPost]
        public async Task<ActionResult> AddMedicalHistory(AddMedicalHistoryDTO historyDTO)
        {
            AddMedicalHistoryQuery medicalHistoryQuery = historyDTO.Map<AddMedicalHistoryQuery>();
            var result = await mediator.Send(medicalHistoryQuery);
            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        } 
        [HttpPut]
        public async Task<ActionResult> EditMedicalHistory(EditMedicalHistoryDTO historyDTO)
        {
            EditMedicalHistoryQuery medicalHistoryQuery = historyDTO.Map<EditMedicalHistoryQuery>();
            var result = await mediator.Send(medicalHistoryQuery);
            return result.IsSuccess ?
                Ok(result) :
                BadRequest(result);
        }
    }
}
