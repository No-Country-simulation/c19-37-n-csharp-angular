using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _Repository;

        public UserRoleService(IUserRoleRepository userroleRepository)
        {
            _Repository = userroleRepository;
        }

        public IEnumerable<UserRoleDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new UserRoleDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public UserRoleDto GetById(int id)
        {
            var userrole = _Repository.GetById(id);
            if (userrole == null) return null;

            return new UserRoleDto
            {
                Id = userrole.Id,
                // Add other properties here
            };
        }

        public void Add(UserRoleDto userroleDto)
        {
            var userrole = new UserRole
            {
                Id = userroleDto.Id,
                // Add other properties here
            };
            _Repository.Add(userrole);
        }

        public void Update(UserRoleDto userroleDto)
        {
            var userrole = new UserRole
            {
                Id = userroleDto.Id,
                // Add other properties here
            };
            _Repository.Update(userrole);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
