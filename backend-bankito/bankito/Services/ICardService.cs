using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface ICardService
    {
        IEnumerable<CardDto> GetAll();
        CardDto GetById(int id);
        void Add(CardDto cardDto);
        void Update(CardDto cardDto);
        void Delete(int id);
    }
}
