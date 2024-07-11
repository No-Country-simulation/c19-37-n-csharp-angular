using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRoleDto> GetAll();
        UserRoleDto GetById(int id);
        void Add(UserRoleDto userroleDto);
        void Update(UserRoleDto userroleDto);
        void Delete(int id);
    }
}
