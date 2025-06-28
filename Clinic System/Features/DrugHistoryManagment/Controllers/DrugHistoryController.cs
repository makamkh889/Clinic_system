using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.InvestigationMangment.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.DrugHistoryManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugHistoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public DrugHistoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvestagationsByVisitId(int id)
        {
            var result = await mediator.Send(new GetInvestagationsByVisitIdQuery { id = id });
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("{id:int}")]
        //public async Task<IActionResult> EditInvestagation(int id, [FromBody] EditInvestagatioDTO editInvestagationDTO)
        //{
        //    var investagationCommand = editInvestagationDTO.Map<EditInvestagationCommand>();
        //    investagationCommand.InvestagationId = id;
        //    var result = await mediator.Send(investagationCommand);

        //    if (result.IsSuccess)
        //        return Ok(result);

        //    return BadRequest(result);
        //}
        [HttpPost]
        //public async Task<IActionResult> AddInvestagation([FromBody] AddInvestagationCommand addInvestagatioDTO)
        //{
        //    var investagationCommand = addInvestagatioDTO.Map<AddInvestagationCommand>();
        //    var result = await mediator.Send(investagationCommand);
        //    if (result.IsSuccess)
        //        return Ok(result);

        //    return BadRequest(result);
        //}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteInvestagation(int id)
        {
            var result = await mediator.Send(new RemoveInvestagationCommand { id = id });
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
