using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillStatusController : ControllerBase
{
    private readonly IBillStatusService _Service;

    public BillStatusController(IBillStatusService billstatusService)
    {
        _Service = billstatusService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BillStatusDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BillStatusDto> GetById(int id)
    {
        var billstatus = _Service.GetById(id);
        if (billstatus == null)
        {
            return NotFound();
        }
        return Ok(billstatus);
    }

    [HttpPost]
    public ActionResult Add(BillStatusDto billstatusDto)
    {
        _Service.Add(billstatusDto);
        return CreatedAtAction(nameof(GetById), new { id = billstatusDto.Id }, billstatusDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BillStatusDto billstatusDto)
    {
        if (id != billstatusDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(billstatusDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
