using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class StatusCardService : IStatusCardService
    {
        private readonly IStatusCardRepository _Repository;

        public StatusCardService(IStatusCardRepository statuscardRepository)
        {
            _Repository = statuscardRepository;
        }

        public IEnumerable<StatusCardDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new StatusCardDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public StatusCardDto GetById(int id)
        {
            var statuscard = _Repository.GetById(id);
            if (statuscard == null) return null;

            return new StatusCardDto
            {
                Id = statuscard.Id,
                // Add other properties here
            };
        }

        public void Add(StatusCardDto statuscardDto)
        {
            var statuscard = new StatusCard
            {
                Id = statuscardDto.Id,
                // Add other properties here
            };
            _Repository.Add(statuscard);
        }

        public void Update(StatusCardDto statuscardDto)
        {
            var statuscard = new StatusCard
            {
                Id = statuscardDto.Id,
                // Add other properties here
            };
            _Repository.Update(statuscard);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
