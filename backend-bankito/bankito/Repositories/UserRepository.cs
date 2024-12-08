using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _s = new List<User>();

        public IEnumerable<User> GetAll() => _s;

        public User GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(User user) => _s.Add(user);

        public void Update(User user)
        {
            var index = _s.FindIndex(p => p.Id == user.Id);
            if (index >= 0) _s[index] = user;
        }

        public void Delete(int id)
        {
            var user = _s.FirstOrDefault(p => p.Id == id);
            if (user != null) _s.Remove(user);
        }
    }
}
