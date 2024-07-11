using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BankTransferRepository : IBankTransferRepository
    {
        private readonly List<BankTransfer> _s = new List<BankTransfer>();

        public IEnumerable<BankTransfer> GetAll() => _s;

        public BankTransfer GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(BankTransfer banktransfer) => _s.Add(banktransfer);

        public void Update(BankTransfer banktransfer)
        {
            var index = _s.FindIndex(p => p.Id == banktransfer.Id);
            if (index >= 0) _s[index] = banktransfer;
        }

        public void Delete(int id)
        {
            var banktransfer = _s.FirstOrDefault(p => p.Id == id);
            if (banktransfer != null) _s.Remove(banktransfer);
        }
    }
}
