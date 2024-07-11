using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class ManualBanRepository : IManualBanRepository
    {
        private readonly List<ManualBan> _s = new List<ManualBan>();

        public IEnumerable<ManualBan> GetAll() => _s;

        public ManualBan GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(ManualBan manualban) => _s.Add(manualban);

        public void Update(ManualBan manualban)
        {
            var index = _s.FindIndex(p => p.Id == manualban.Id);
            if (index >= 0) _s[index] = manualban;
        }

        public void Delete(int id)
        {
            var manualban = _s.FirstOrDefault(p => p.Id == id);
            if (manualban != null) _s.Remove(manualban);
        }
    }
}
