using Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Command;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.CQRS.Query;
using Clinic_managment_System.Clinic_System.Features.MedicineMangment.DTO;
using Clinic_managment_System.Clinic_System.Shared.ResultsOfAPI;
using InventoryManagmentSystem.Shared.MapperServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_managment_System.Clinic_System.Features.MedicineMangment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMediator mediator;
        public MedicineController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddMedicine(AddMedicineDTO addMedicineDTO)
        {
            if (ModelState.IsValid)
            {
                AddMedicineQuery addMedicineQuery = addMedicineDTO.Map<AddMedicineQuery>();
                Result<string> result = await mediator.Send(addMedicineQuery);
                return result.IsSuccess
               ? Ok(result)
               : BadRequest(result);
            }
            return BadRequest(addMedicineDTO);
        }

        [HttpGet("/SearchByName")]
        public async Task<ActionResult> SearchByName(string Name)
        {
            Result<List<GetMedicinDTO>> result = await mediator.Send(new GetMedicinByNameQuery
            {
                MedicinName = Name
            });
            return result.IsSuccess
           ? Ok(result)
           : BadRequest(result);
        }
        [HttpGet("/SearchByCode")]
        public async Task<ActionResult> SearchByCode(string Code)
        {
            Result<List<GetMedicinDTO>> result = await mediator.Send(new GetMedicinByIdQuery
            {
                MedicinCode = Code
            });
            return result.IsSuccess
           ? Ok(result)
           : BadRequest(result);
        }

        [HttpPost("upload-excel")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            var addedCount = 0;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var workbook = new ClosedXML.Excel.XLWorkbook(stream))
                {
                    var worksheet = workbook.Worksheets.First();
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1).Take(1000); // skip header

                    foreach (var row in rows)
                    {
                        var dto = new AddMedicineDTO
                        {
                            MedicineCode = row.Cell(1).GetString(),
                            TradeName = row.Cell(2).GetString(),
                            Composition = row.Cell(3).GetString(),
                            Concentration = row.Cell(4).GetString(),
                            Unit = row.Cell(5).GetString(),
                            PharmaceuticalForm = row.Cell(6).GetString(),
                            Company = row.Cell(7).GetString(),
                            RegistrationNumber = row.Cell(8).GetString(),
                            MedicineType = row.Cell(9).GetString()
                        };

                        var command = dto.Map<AddMedicineQuery>();
                        var result = await mediator.Send(command);
                        if (result.IsSuccess)
                            addedCount++;
                    }
                }
            }

            return Ok(Result<string>.Success($"{addedCount} medicines added successfully."));
        }


    }
}
