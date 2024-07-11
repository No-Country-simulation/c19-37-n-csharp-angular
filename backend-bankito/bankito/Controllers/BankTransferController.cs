using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankTransferController : ControllerBase
{
    private readonly IBankTransferService _Service;

    public BankTransferController(IBankTransferService banktransferService)
    {
        _Service = banktransferService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BankTransferDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BankTransferDto> GetById(int id)
    {
        var banktransfer = _Service.GetById(id);
        if (banktransfer == null)
        {
            return NotFound();
        }
        return Ok(banktransfer);
    }

    [HttpPost]
    public ActionResult Add(BankTransferDto banktransferDto)
    {
        _Service.Add(banktransferDto);
        return CreatedAtAction(nameof(GetById), new { id = banktransferDto.Id }, banktransferDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BankTransferDto banktransferDto)
    {
        if (id != banktransferDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(banktransferDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
