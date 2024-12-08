using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BanController : ControllerBase
{
    private readonly IBanService _Service;

    public BanController(IBanService banService)
    {
        _Service = banService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BanDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BanDto> GetById(int id)
    {
        var ban = _Service.GetById(id);
        if (ban == null)
        {
            return NotFound();
        }
        return Ok(ban);
    }

    [HttpPost]
    public ActionResult Add(BanDto banDto)
    {
        _Service.Add(banDto);
        return CreatedAtAction(nameof(GetById), new { id = banDto.Id }, banDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BanDto banDto)
    {
        if (id != banDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(banDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
