using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly List<Role> _s = new List<Role>();

        public IEnumerable<Role> GetAll() => _s;

        public Role GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Role role) => _s.Add(role);

        public void Update(Role role)
        {
            var index = _s.FindIndex(p => p.Id == role.Id);
            if (index >= 0) _s[index] = role;
        }

        public void Delete(int id)
        {
            var role = _s.FirstOrDefault(p => p.Id == id);
            if (role != null) _s.Remove(role);
        }
    }
}
