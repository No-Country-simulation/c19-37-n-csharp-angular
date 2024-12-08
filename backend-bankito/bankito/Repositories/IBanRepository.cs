using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IBanRepository
    {
        IEnumerable<Ban> GetAll();
        Ban GetById(int id);
        void Add(Ban ban);
        void Update(Ban ban);
        void Delete(int id);
    }
}
