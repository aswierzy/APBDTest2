using Microsoft.AspNetCore.Mvc;
using apbdtest2.DTOs;

namespace apbdtest2.Controllers;

[ApiController]
[Route("api/records")]
public class RecordController : ControllerBase
{
    private readonly IRecordService _service;

    public RecordController(IRecordService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecords([FromQuery] DateTime? fromDate, int? languageId, int? taskId)
    {
        var records = await _service.GetRecords(fromDate, languageId, taskId);
        return Ok(records);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecord([FromBody] CreateRecordDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.CreateRecord(dto);
        return result ? Ok("Record created successfully.") : BadRequest("Wrong student, language, or task data.");
    }
}