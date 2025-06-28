using Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.VisitManagment.DTO;
using InventoryManagmentSystem.Shared.MapperServices;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.VisitManagment
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IMediator mediator;
        public VisitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetVisitByIdQuery { Id = id });
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        } 

        [HttpGet("GetVBPat/{id:int}")]
        public async Task<IActionResult> GetVisitByPatientId(int id)
        {
            var result = await mediator.Send(new GetVisitByPatientIdQuery { Id = id });
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> EditVisit(int id, [FromBody] EditVisitDTO editVisitDTO)
        {
            editVisitDTO.VisitId = id;
            var visitQuery = editVisitDTO.Map<EditVisitCommand>();
            var result = await mediator.Send(visitQuery);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
