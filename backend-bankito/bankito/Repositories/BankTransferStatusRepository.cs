using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class BankTransferStatusRepository : IBankTransferStatusRepository
    {
        private readonly List<BankTransferStatus> _s = new List<BankTransferStatus>();

        public IEnumerable<BankTransferStatus> GetAll() => _s;

        public BankTransferStatus GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(BankTransferStatus banktransferstatus) => _s.Add(banktransferstatus);

        public void Update(BankTransferStatus banktransferstatus)
        {
            var index = _s.FindIndex(p => p.Id == banktransferstatus.Id);
            if (index >= 0) _s[index] = banktransferstatus;
        }

        public void Delete(int id)
        {
            var banktransferstatus = _s.FirstOrDefault(p => p.Id == id);
            if (banktransferstatus != null) _s.Remove(banktransferstatus);
        }
    }
}
