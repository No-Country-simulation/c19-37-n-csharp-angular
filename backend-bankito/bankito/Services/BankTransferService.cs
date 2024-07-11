using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BankTransferService : IBankTransferService
    {
        private readonly IBankTransferRepository _Repository;

        public BankTransferService(IBankTransferRepository banktransferRepository)
        {
            _Repository = banktransferRepository;
        }

        public IEnumerable<BankTransferDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BankTransferDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BankTransferDto GetById(int id)
        {
            var banktransfer = _Repository.GetById(id);
            if (banktransfer == null) return null;

            return new BankTransferDto
            {
                Id = banktransfer.Id,
                // Add other properties here
            };
        }

        public void Add(BankTransferDto banktransferDto)
        {
            var banktransfer = new BankTransfer
            {
                Id = banktransferDto.Id,
                // Add other properties here
            };
            _Repository.Add(banktransfer);
        }

        public void Update(BankTransferDto banktransferDto)
        {
            var banktransfer = new BankTransfer
            {
                Id = banktransferDto.Id,
                // Add other properties here
            };
            _Repository.Update(banktransfer);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
