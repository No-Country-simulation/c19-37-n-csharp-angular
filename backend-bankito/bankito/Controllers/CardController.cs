using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _Service;

    public CardController(ICardService cardService)
    {
        _Service = cardService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CardDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<CardDto> GetById(int id)
    {
        var card = _Service.GetById(id);
        if (card == null)
        {
            return NotFound();
        }
        return Ok(card);
    }

    [HttpPost]
    public ActionResult Add(CardDto cardDto)
    {
        _Service.Add(cardDto);
        return CreatedAtAction(nameof(GetById), new { id = cardDto.Id }, cardDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, CardDto cardDto)
    {
        if (id != cardDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(cardDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
