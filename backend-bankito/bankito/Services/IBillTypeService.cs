using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBillTypeService
    {
        IEnumerable<BillTypeDto> GetAll();
        BillTypeDto GetById(int id);
        void Add(BillTypeDto billtypeDto);
        void Update(BillTypeDto billtypeDto);
        void Delete(int id);
    }
}
