using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _Service;

    public RoleController(IRoleService roleService)
    {
        _Service = roleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<RoleDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<RoleDto> GetById(int id)
    {
        var role = _Service.GetById(id);
        if (role == null)
        {
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public ActionResult Add(RoleDto roleDto)
    {
        _Service.Add(roleDto);
        return CreatedAtAction(nameof(GetById), new { id = roleDto.Id }, roleDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, RoleDto roleDto)
    {
        if (id != roleDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(roleDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
