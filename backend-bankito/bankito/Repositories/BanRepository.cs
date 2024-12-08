using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BanRepository : IBanRepository
    {
        private readonly List<Ban> _s = new List<Ban>();

        public IEnumerable<Ban> GetAll() => _s;

        public Ban GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Ban ban) => _s.Add(ban);

        public void Update(Ban ban)
        {
            var index = _s.FindIndex(p => p.Id == ban.Id);
            if (index >= 0) _s[index] = ban;
        }

        public void Delete(int id)
        {
            var ban = _s.FirstOrDefault(p => p.Id == id);
            if (ban != null) _s.Remove(ban);
        }
    }
}
