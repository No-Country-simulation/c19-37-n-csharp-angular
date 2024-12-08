using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _Repository;

        public RoleService(IRoleRepository roleRepository)
        {
            _Repository = roleRepository;
        }

        public IEnumerable<RoleDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new RoleDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public RoleDto GetById(int id)
        {
            var role = _Repository.GetById(id);
            if (role == null) return null;

            return new RoleDto
            {
                Id = role.Id,
                // Add other properties here
            };
        }

        public void Add(RoleDto roleDto)
        {
            var role = new Role
            {
                Id = roleDto.Id,
                // Add other properties here
            };
            _Repository.Add(role);
        }

        public void Update(RoleDto roleDto)
        {
            var role = new Role
            {
                Id = roleDto.Id,
                // Add other properties here
            };
            _Repository.Update(role);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
