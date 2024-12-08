using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<Card> _s = new List<Card>();

        public IEnumerable<Card> GetAll() => _s;

        public Card GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Card card) => _s.Add(card);

        public void Update(Card card)
        {
            var index = _s.FindIndex(p => p.Id == card.Id);
            if (index >= 0) _s[index] = card;
        }

        public void Delete(int id)
        {
            var card = _s.FirstOrDefault(p => p.Id == id);
            if (card != null) _s.Remove(card);
        }
    }
}
