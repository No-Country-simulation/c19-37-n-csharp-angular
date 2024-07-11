using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusCardController : ControllerBase
{
    private readonly IStatusCardService _Service;

    public StatusCardController(IStatusCardService statuscardService)
    {
        _Service = statuscardService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<StatusCardDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<StatusCardDto> GetById(int id)
    {
        var statuscard = _Service.GetById(id);
        if (statuscard == null)
        {
            return NotFound();
        }
        return Ok(statuscard);
    }

    [HttpPost]
    public ActionResult Add(StatusCardDto statuscardDto)
    {
        _Service.Add(statuscardDto);
        return CreatedAtAction(nameof(GetById), new { id = statuscardDto.Id }, statuscardDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, StatusCardDto statuscardDto)
    {
        if (id != statuscardDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(statuscardDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
