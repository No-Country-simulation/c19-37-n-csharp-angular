using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BillStatusRepository : IBillStatusRepository
    {
        private readonly List<BillStatus> _s = new List<BillStatus>();

        public IEnumerable<BillStatus> GetAll() => _s;

        public BillStatus GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(BillStatus billstatus) => _s.Add(billstatus);

        public void Update(BillStatus billstatus)
        {
            var index = _s.FindIndex(p => p.Id == billstatus.Id);
            if (index >= 0) _s[index] = billstatus;
        }

        public void Delete(int id)
        {
            var billstatus = _s.FirstOrDefault(p => p.Id == id);
            if (billstatus != null) _s.Remove(billstatus);
        }
    }
}
