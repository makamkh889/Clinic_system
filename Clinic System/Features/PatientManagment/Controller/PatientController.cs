using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Commands;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Orchestrators;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.CQRS.Queries;
using Clinic_managment_System.Clinic_System.Features.PatientManagment.DTOs;
using Clinic_managment_System.Clinic_System.Shared.Enum;
using InventoryManagmentSystem.Shared.MapperServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.PatientManagment
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IMediator mediator;

        public PatientController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] AddPatientDTO addPatientDTO)
        {
            //if (!Enum.IsDefined(typeof(MaritalStatus), addPatientDTO.MaritalStatus ))
            //{
            //    ModelState.AddModelError(nameof(addPatientDTO.MaritalStatus), "Invalid marital status.");
            //}

            //if (!Enum.IsDefined(typeof(Gender), addPatientDTO.Gender))
            //{
            //    ModelState.AddModelError(nameof(addPatientDTO.Gender), "Invalid marital Gender.");
            //}
            if (ModelState.IsValid)
            {
                AddPatientOrchestrat addPatientOrchestrat = addPatientDTO.Map<AddPatientOrchestrat>();
                Result<string> res = await mediator.Send(addPatientOrchestrat);
                if (res.IsSuccess)
                {
                    return Ok(res);
                }
                return BadRequest(res);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetPatient(int id)
        {
            GetPatientByIdQuery getPatientQuery = new()
            {
                 Id=id
            };

            Result<GetPatientDetailsDTO> res = await mediator.Send(getPatientQuery);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetPatient(string name)
        {
            GetPatientByNameQuery getPatientQuery = new()
            {
                FullName = name
            };

            Result<GetPatientDetailsDTO> res = await mediator.Send(getPatientQuery);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
        
        [HttpGet()]
        public async Task<ActionResult> GetAllPatient(int page=1)//page has 8
        {
            GetAllPatientsQuery getPatientQuery = new()
            {
                Take = page
            };

            Result<List<GetAllPatientDTO>> res = await mediator.Send(getPatientQuery);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }


        [HttpPut]
        public async Task<ActionResult> EditPatient([FromBody] EditPatientDTO editPatientDTO)
        {
            if (ModelState.IsValid)
            {
                EditPatientCommand editPatientCommand = editPatientDTO.Map<EditPatientCommand>();
                Result<bool> res = await mediator.Send(editPatientCommand);
                if (res.IsSuccess)
                {
                    return Ok(res);
                }
                return BadRequest(res);
            }
            return BadRequest(ModelState);
        }

    }

    public static class MappingExtensions
    {
        public static AddPatientOrchestrat MapToOrchestrat(this AddPatientDTO dto)
        {
            return new AddPatientOrchestrat
            {
                FullName = dto.FullName,
                Age = dto.Age,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                MaritalStatus = dto.MaritalStatus,
                Occupation = dto.Occupation,
                DateOfVisit = dto.DateOfVisit,
                Pulse = dto.Pulse,
                Temperature = dto.Temperature,
                OxygenSaturation = dto.OxygenSaturation,
                BloodSugar = dto.BloodSugar,
                Hemoglobin = dto.Hemoglobin,
                Weight = dto.Weight
            };
        }
    }
}
