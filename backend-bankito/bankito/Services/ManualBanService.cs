using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class ManualBanService : IManualBanService
    {
        private readonly IManualBanRepository _Repository;

        public ManualBanService(IManualBanRepository manualbanRepository)
        {
            _Repository = manualbanRepository;
        }

        public IEnumerable<ManualBanDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new ManualBanDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public ManualBanDto GetById(int id)
        {
            var manualban = _Repository.GetById(id);
            if (manualban == null) return null;

            return new ManualBanDto
            {
                Id = manualban.Id,
                // Add other properties here
            };
        }

        public void Add(ManualBanDto manualbanDto)
        {
            var manualban = new ManualBan
            {
                Id = manualbanDto.Id,
                // Add other properties here
            };
            _Repository.Add(manualban);
        }

        public void Update(ManualBanDto manualbanDto)
        {
            var manualban = new ManualBan
            {
                Id = manualbanDto.Id,
                // Add other properties here
            };
            _Repository.Update(manualban);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
