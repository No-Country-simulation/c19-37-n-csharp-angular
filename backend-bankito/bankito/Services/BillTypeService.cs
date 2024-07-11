using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BillTypeService : IBillTypeService
    {
        private readonly IBillTypeRepository _Repository;

        public BillTypeService(IBillTypeRepository billtypeRepository)
        {
            _Repository = billtypeRepository;
        }

        public IEnumerable<BillTypeDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BillTypeDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BillTypeDto GetById(int id)
        {
            var billtype = _Repository.GetById(id);
            if (billtype == null) return null;

            return new BillTypeDto
            {
                Id = billtype.Id,
                // Add other properties here
            };
        }

        public void Add(BillTypeDto billtypeDto)
        {
            var billtype = new BillType
            {
                Id = billtypeDto.Id,
                // Add other properties here
            };
            _Repository.Add(billtype);
        }

        public void Update(BillTypeDto billtypeDto)
        {
            var billtype = new BillType
            {
                Id = billtypeDto.Id,
                // Add other properties here
            };
            _Repository.Update(billtype);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
