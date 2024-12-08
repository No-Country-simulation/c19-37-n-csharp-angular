using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBillTypeRepository
    {
        IEnumerable<BillType> GetAll();
        BillType GetById(int id);
        void Add(BillType billtype);
        void Update(BillType billtype);
        void Delete(int id);
    }
}
