using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BillTypeController : ControllerBase
{
    private readonly IBillTypeService _Service;

    public BillTypeController(IBillTypeService billtypeService)
    {
        _Service = billtypeService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BillTypeDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BillTypeDto> GetById(int id)
    {
        var billtype = _Service.GetById(id);
        if (billtype == null)
        {
            return NotFound();
        }
        return Ok(billtype);
    }

    [HttpPost]
    public ActionResult Add(BillTypeDto billtypeDto)
    {
        _Service.Add(billtypeDto);
        return CreatedAtAction(nameof(GetById), new { id = billtypeDto.Id }, billtypeDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BillTypeDto billtypeDto)
    {
        if (id != billtypeDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(billtypeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
