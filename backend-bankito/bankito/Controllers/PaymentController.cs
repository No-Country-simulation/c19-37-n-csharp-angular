using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _Service;

    public PaymentController(IPaymentService paymentService)
    {
        _Service = paymentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PaymentDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<PaymentDto> GetById(int id)
    {
        var payment = _Service.GetById(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }

    [HttpPost]
    public ActionResult Add(PaymentDto paymentDto)
    {
        _Service.Add(paymentDto);
        return CreatedAtAction(nameof(GetById), new { id = paymentDto.Id }, paymentDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, PaymentDto paymentDto)
    {
        if (id != paymentDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(paymentDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
