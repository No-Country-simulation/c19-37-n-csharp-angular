using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankTransferStatusController : ControllerBase
{
    private readonly IBankTransferStatusService _Service;

    public BankTransferStatusController(IBankTransferStatusService banktransferstatusService)
    {
        _Service = banktransferstatusService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BankTransferStatusDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BankTransferStatusDto> GetById(int id)
    {
        var banktransferstatus = _Service.GetById(id);
        if (banktransferstatus == null)
        {
            return NotFound();
        }
        return Ok(banktransferstatus);
    }

    [HttpPost]
    public ActionResult Add(BankTransferStatusDto banktransferstatusDto)
    {
        _Service.Add(banktransferstatusDto);
        return CreatedAtAction(nameof(GetById), new { id = banktransferstatusDto.Id }, banktransferstatusDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, BankTransferStatusDto banktransferstatusDto)
    {
        if (id != banktransferstatusDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(banktransferstatusDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
