using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class StatusCardRepository : IStatusCardRepository
    {
        private readonly List<StatusCard> _s = new List<StatusCard>();

        public IEnumerable<StatusCard> GetAll() => _s;

        public StatusCard GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(StatusCard statuscard) => _s.Add(statuscard);

        public void Update(StatusCard statuscard)
        {
            var index = _s.FindIndex(p => p.Id == statuscard.Id);
            if (index >= 0) _s[index] = statuscard;
        }

        public void Delete(int id)
        {
            var statuscard = _s.FirstOrDefault(p => p.Id == id);
            if (statuscard != null) _s.Remove(statuscard);
        }
    }
}
