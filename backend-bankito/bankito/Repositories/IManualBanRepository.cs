using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IManualBanRepository
    {
        IEnumerable<ManualBan> GetAll();
        ManualBan GetById(int id);
        void Add(ManualBan manualban);
        void Update(ManualBan manualban);
        void Delete(int id);
    }
}
