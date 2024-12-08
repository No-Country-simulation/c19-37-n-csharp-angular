using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBankTransferRepository
    {
        IEnumerable<BankTransfer> GetAll();
        BankTransfer GetById(int id);
        void Add(BankTransfer banktransfer);
        void Update(BankTransfer banktransfer);
        void Delete(int id);
    }
}
