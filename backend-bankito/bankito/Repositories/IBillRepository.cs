using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBillRepository
    {
        IEnumerable<Bill> GetAll();
        Bill GetById(int id);
        void Add(Bill bill);
        void Update(Bill bill);
        void Delete(int id);
    }
}
