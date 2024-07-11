using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BillTypeRepository : IBillTypeRepository
    {
        private readonly List<BillType> _s = new List<BillType>();

        public IEnumerable<BillType> GetAll() => _s;

        public BillType GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(BillType billtype) => _s.Add(billtype);

        public void Update(BillType billtype)
        {
            var index = _s.FindIndex(p => p.Id == billtype.Id);
            if (index >= 0) _s[index] = billtype;
        }

        public void Delete(int id)
        {
            var billtype = _s.FirstOrDefault(p => p.Id == id);
            if (billtype != null) _s.Remove(billtype);
        }
    }
}
