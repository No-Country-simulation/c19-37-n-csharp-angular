using Microsoft.AspNetCore.Mvc;
using bankito.DTOs;
using bankito.Services;

namespace bankito.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserRoleController : ControllerBase
{
    private readonly IUserRoleService _Service;

    public UserRoleController(IUserRoleService userroleService)
    {
        _Service = userroleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserRoleDto>> GetAll()
    {
        return Ok(_Service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<UserRoleDto> GetById(int id)
    {
        var userrole = _Service.GetById(id);
        if (userrole == null)
        {
            return NotFound();
        }
        return Ok(userrole);
    }

    [HttpPost]
    public ActionResult Add(UserRoleDto userroleDto)
    {
        _Service.Add(userroleDto);
        return CreatedAtAction(nameof(GetById), new { id = userroleDto.Id }, userroleDto);
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, UserRoleDto userroleDto)
    {
        if (id != userroleDto.Id)
        {
            return BadRequest();
        }
        _Service.Update(userroleDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _Service.Delete(id);
        return NoContent();
    }
}
