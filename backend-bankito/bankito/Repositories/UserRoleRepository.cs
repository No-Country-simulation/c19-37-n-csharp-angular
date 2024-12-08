using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly List<UserRole> _s = new List<UserRole>();

        public IEnumerable<UserRole> GetAll() => _s;

        public UserRole GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(UserRole userrole) => _s.Add(userrole);

        public void Update(UserRole userrole)
        {
            var index = _s.FindIndex(p => p.Id == userrole.Id);
            if (index >= 0) _s[index] = userrole;
        }

        public void Delete(int id)
        {
            var userrole = _s.FirstOrDefault(p => p.Id == id);
            if (userrole != null) _s.Remove(userrole);
        }
    }
}
