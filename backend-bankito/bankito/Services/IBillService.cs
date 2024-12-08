using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBillService
    {
        IEnumerable<BillDto> GetAll();
        BillDto GetById(int id);
        void Add(BillDto billDto);
        void Update(BillDto billDto);
        void Delete(int id);
    }
}
