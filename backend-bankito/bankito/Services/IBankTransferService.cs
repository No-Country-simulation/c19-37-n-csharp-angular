using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBankTransferService
    {
        IEnumerable<BankTransferDto> GetAll();
        BankTransferDto GetById(int id);
        void Add(BankTransferDto banktransferDto);
        void Update(BankTransferDto banktransferDto);
        void Delete(int id);
    }
}
