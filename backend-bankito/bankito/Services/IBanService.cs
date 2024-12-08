using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IBanService
    {
        IEnumerable<BanDto> GetAll();
        BanDto GetById(int id);
        void Add(BanDto banDto);
        void Update(BanDto banDto);
        void Delete(int id);
    }
}
