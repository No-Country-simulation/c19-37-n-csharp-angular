using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManualBanController : ControllerBase
{
    private readonly IManualBanService _Service;

    public ManualBanController(IManualBanService manualbanService)
    {
        _Service = manualbanService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ManualBanDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<ManualBanDto> GetById(int id)
    {
        var manualban = _Service.GetById(id);
        if (manualban == null)
        {
            return NotFound();
        }
        return Ok(manualban);
    }

    [HttpPost]
    public ActionResult Add(ManualBanDto manualbanDto)
    {
        _Service.Add(manualbanDto);
        return CreatedAtAction(nameof(GetById), new { id = manualbanDto.Id }, manualbanDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, ManualBanDto manualbanDto)
    {
        if (id != manualbanDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(manualbanDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
