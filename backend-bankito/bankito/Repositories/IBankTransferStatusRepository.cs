using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBankTransferStatusRepository
    {
        IEnumerable<BankTransferStatus> GetAll();
        BankTransferStatus GetById(int id);
        void Add(BankTransferStatus banktransferstatus);
        void Update(BankTransferStatus banktransferstatus);
        void Delete(int id);
    }
}
