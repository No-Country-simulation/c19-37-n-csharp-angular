using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _Service;

    public UserController(IUserService userService)
    {
        _Service = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> GetById(int id)
    {
        var user = _Service.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult Add(UserDto userDto)
    {
        _Service.Add(userDto);
        return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, UserDto userDto)
    {
        if (id != userDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
