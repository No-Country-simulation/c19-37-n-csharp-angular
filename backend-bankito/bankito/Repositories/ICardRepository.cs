using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
        Card GetById(int id);
        void Add(Card card);
        void Update(Card card);
        void Delete(int id);
    }
}
