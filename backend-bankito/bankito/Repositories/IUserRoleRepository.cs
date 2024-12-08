using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAll();
        UserRole GetById(int id);
        void Add(UserRole userrole);
        void Update(UserRole userrole);
        void Delete(int id);
    }
}
