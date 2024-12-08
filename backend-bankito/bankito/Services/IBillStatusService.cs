using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBillStatusService
    {
        IEnumerable<BillStatusDto> GetAll();
        BillStatusDto GetById(int id);
        void Add(BillStatusDto billstatusDto);
        void Update(BillStatusDto billstatusDto);
        void Delete(int id);
    }
}
