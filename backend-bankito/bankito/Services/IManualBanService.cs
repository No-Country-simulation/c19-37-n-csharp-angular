using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IManualBanService
    {
        IEnumerable<ManualBanDto> GetAll();
        ManualBanDto GetById(int id);
        void Add(ManualBanDto manualbanDto);
        void Update(ManualBanDto manualbanDto);
        void Delete(int id);
    }
}
