using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBankTransferStatusService
    {
        IEnumerable<BankTransferStatusDto> GetAll();
        BankTransferStatusDto GetById(int id);
        void Add(BankTransferStatusDto banktransferstatusDto);
        void Update(BankTransferStatusDto banktransferstatusDto);
        void Delete(int id);
    }
}
