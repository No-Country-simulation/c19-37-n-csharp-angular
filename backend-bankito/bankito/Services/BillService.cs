using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _Repository;

        public BillService(IBillRepository billRepository)
        {
            _Repository = billRepository;
        }

        public IEnumerable<BillDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BillDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BillDto GetById(int id)
        {
            var bill = _Repository.GetById(id);
            if (bill == null) return null;

            return new BillDto
            {
                Id = bill.Id,
                // Add other properties here
            };
        }

        public void Add(BillDto billDto)
        {
            var bill = new Bill
            {
                Id = billDto.Id,
                // Add other properties here
            };
            _Repository.Add(bill);
        }

        public void Update(BillDto billDto)
        {
            var bill = new Bill
            {
                Id = billDto.Id,
                // Add other properties here
            };
            _Repository.Update(bill);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
