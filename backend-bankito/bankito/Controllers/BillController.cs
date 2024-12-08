using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillController : ControllerBase
{
    private readonly IBillService _Service;

    public BillController(IBillService billService)
    {
        _Service = billService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BillDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BillDto> GetById(int id)
    {
        var bill = _Service.GetById(id);
        if (bill == null)
        {
            return NotFound();
        }
        return Ok(bill);
    }

    [HttpPost]
    public ActionResult Add(BillDto billDto)
    {
        _Service.Add(billDto);
        return CreatedAtAction(nameof(GetById), new { id = billDto.Id }, billDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BillDto billDto)
    {
        if (id != billDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(billDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
