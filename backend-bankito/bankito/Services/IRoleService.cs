using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        RoleDto GetById(int id);
        void Add(RoleDto roleDto);
        void Update(RoleDto roleDto);
        void Delete(int id);
    }
}
