using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IStatusCardRepository
    {
        IEnumerable<StatusCard> GetAll();
        StatusCard GetById(int id);
        void Add(StatusCard statuscard);
        void Update(StatusCard statuscard);
        void Delete(int id);
    }
}
