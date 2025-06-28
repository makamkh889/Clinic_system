using Clinic_managment_System.Clinic_System.Features.AccountManagment.CQRS.Commands;
using Clinic_managment_System.Clinic_System.Features.AccountManagment.CQRS.queries;
using Clinic_managment_System.Clinic_System.Features.AccountManagment.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.AccountManagment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            LoginQuery loginQuery = new()
            {
                UserName = loginDTO.UserName,
                Password = loginDTO.Password,
                RemeberMe=loginDTO.RemeberMe
            };

            if (ModelState.IsValid)
            {
                Result<string> result = await mediator.Send(loginQuery);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(Result<bool>.Failure("User Log In Credintial Is Not Valid"));
        }
        [HttpPost("reg")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                RegisterCommand registerCommand = new()
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };
                Result<string> result = await mediator.Send(registerCommand);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(Result<bool>.Failure("User Register Credintial Is Not Valid"));
        }
        [HttpGet("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            LogOutQuery logOutQuery = new();
            await mediator.Send(logOutQuery);
            return Ok();
        }
    }
}
