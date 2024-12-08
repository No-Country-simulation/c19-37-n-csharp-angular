using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _Service;

    public CountryController(ICountryService countryService)
    {
        _Service = countryService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CountryDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<CountryDto> GetById(int id)
    {
        var country = _Service.GetById(id);
        if (country == null)
        {
            return NotFound();
        }
        return Ok(country);
    }

    [HttpPost]
    public ActionResult Add(CountryDto countryDto)
    {
        _Service.Add(countryDto);
        return CreatedAtAction(nameof(GetById), new { id = countryDto.Id }, countryDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, CountryDto countryDto)
    {
        if (id != countryDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(countryDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
