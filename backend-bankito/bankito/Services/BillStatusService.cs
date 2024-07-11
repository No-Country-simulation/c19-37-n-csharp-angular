using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BillStatusService : IBillStatusService
    {
        private readonly IBillStatusRepository _Repository;

        public BillStatusService(IBillStatusRepository billstatusRepository)
        {
            _Repository = billstatusRepository;
        }

        public IEnumerable<BillStatusDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BillStatusDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BillStatusDto GetById(int id)
        {
            var billstatus = _Repository.GetById(id);
            if (billstatus == null) return null;

            return new BillStatusDto
            {
                Id = billstatus.Id,
                // Add other properties here
            };
        }

        public void Add(BillStatusDto billstatusDto)
        {
            var billstatus = new BillStatus
            {
                Id = billstatusDto.Id,
                // Add other properties here
            };
            _Repository.Add(billstatus);
        }

        public void Update(BillStatusDto billstatusDto)
        {
            var billstatus = new BillStatus
            {
                Id = billstatusDto.Id,
                // Add other properties here
            };
            _Repository.Update(billstatus);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
