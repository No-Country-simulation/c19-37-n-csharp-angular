using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);
        void Add(UserDto userDto);
        void Update(UserDto userDto);
        void Delete(int id);
    }
}
