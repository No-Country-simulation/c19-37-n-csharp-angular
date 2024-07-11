using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _Repository;

        public CardService(ICardRepository cardRepository)
        {
            _Repository = cardRepository;
        }

        public IEnumerable<CardDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new CardDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public CardDto GetById(int id)
        {
            var card = _Repository.GetById(id);
            if (card == null) return null;

            return new CardDto
            {
                Id = card.Id,
                // Add other properties here
            };
        }

        public void Add(CardDto cardDto)
        {
            var card = new Card
            {
                Id = cardDto.Id,
                // Add other properties here
            };
            _Repository.Add(card);
        }

        public void Update(CardDto cardDto)
        {
            var card = new Card
            {
                Id = cardDto.Id,
                // Add other properties here
            };
            _Repository.Update(card);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
