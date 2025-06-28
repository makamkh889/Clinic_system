using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.TreatmentManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Clinic_managment_System.Clinic_System.Features.TreatmentManagment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly IMediator mediator;
        public TreatmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddTreatment(AddTreatmentDTO addTreatmentDTO)
        {
            AddTreatmentQuery addTreatmentQuery = addTreatmentDTO.Map<AddTreatmentQuery>();
            var result = await mediator.Send(addTreatmentQuery);
            return result.IsSuccess
                     ? Ok(result)
                     : BadRequest(result);
        }
        [HttpPut]
        public async Task<ActionResult> EditTreatment(EditTreatmentPlanDTO editTreatmentDTO)
        {
            EditTreatmentQuery EditTreatmentQuery = editTreatmentDTO.Map<EditTreatmentQuery>();
            var result = await mediator.Send(EditTreatmentQuery);
            return result.IsSuccess
                     ? Ok(result)
                     : BadRequest(result);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTreatmentByVisitId(int id)
        {
            var result = await mediator.Send(new GetTreatmentByVisitIdQuery { id = id });
            return result.IsSuccess
                     ? Ok(result)
                     : BadRequest(result);
        }


    }
}
