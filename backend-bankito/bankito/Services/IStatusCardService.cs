using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IStatusCardService
    {
        IEnumerable<StatusCardDto> GetAll();
        StatusCardDto GetById(int id);
        void Add(StatusCardDto statuscardDto);
        void Update(StatusCardDto statuscardDto);
        void Delete(int id);
    }
}
