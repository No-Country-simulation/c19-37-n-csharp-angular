using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _Repository;

        public UserService(IUserRepository userRepository)
        {
            _Repository = userRepository;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new UserDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public UserDto GetById(int id)
        {
            var user = _Repository.GetById(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                // Add other properties here
            };
        }

        public void Add(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                // Add other properties here
            };
            _Repository.Add(user);
        }

        public void Update(UserDto userDto)
        {
            var user = new User
            {
                Id = userDto.Id,
                // Add other properties here
            };
            _Repository.Update(user);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
