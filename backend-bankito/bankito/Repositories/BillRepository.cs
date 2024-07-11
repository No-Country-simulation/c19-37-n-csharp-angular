using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly List<Bill> _s = new List<Bill>();

        public IEnumerable<Bill> GetAll() => _s;

        public Bill GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Bill bill) => _s.Add(bill);

        public void Update(Bill bill)
        {
            var index = _s.FindIndex(p => p.Id == bill.Id);
            if (index >= 0) _s[index] = bill;
        }

        public void Delete(int id)
        {
            var bill = _s.FirstOrDefault(p => p.Id == id);
            if (bill != null) _s.Remove(bill);
        }
    }
}
