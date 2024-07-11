using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBillStatusRepository
    {
        IEnumerable<BillStatus> GetAll();
        BillStatus GetById(int id);
        void Add(BillStatus billstatus);
        void Update(BillStatus billstatus);
        void Delete(int id);
    }
}
