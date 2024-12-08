using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BanService : IBanService
    {
        private readonly IBanRepository _Repository;

        public BanService(IBanRepository banRepository)
        {
            _Repository = banRepository;
        }

        public IEnumerable<BanDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BanDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BanDto GetById(int id)
        {
            var ban = _Repository.GetById(id);
            if (ban == null) return null;

            return new BanDto
            {
                Id = ban.Id,
                // Add other properties here
            };
        }

        public void Add(BanDto banDto)
        {
            var ban = new Ban
            {
                Id = banDto.Id,
                // Add other properties here
            };
            _Repository.Add(ban);
        }

        public void Update(BanDto banDto)
        {
            var ban = new Ban
            {
                Id = banDto.Id,
                // Add other properties here
            };
            _Repository.Update(ban);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
