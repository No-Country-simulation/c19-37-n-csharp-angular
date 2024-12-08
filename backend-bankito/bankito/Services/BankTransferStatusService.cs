using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class BankTransferStatusService : IBankTransferStatusService
    {
        private readonly IBankTransferStatusRepository _Repository;

        public BankTransferStatusService(IBankTransferStatusRepository banktransferstatusRepository)
        {
            _Repository = banktransferstatusRepository;
        }

        public IEnumerable<BankTransferStatusDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new BankTransferStatusDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public BankTransferStatusDto GetById(int id)
        {
            var banktransferstatus = _Repository.GetById(id);
            if (banktransferstatus == null) return null;

            return new BankTransferStatusDto
            {
                Id = banktransferstatus.Id,
                // Add other properties here
            };
        }

        public void Add(BankTransferStatusDto banktransferstatusDto)
        {
            var banktransferstatus = new BankTransferStatus
            {
                Id = banktransferstatusDto.Id,
                // Add other properties here
            };
            _Repository.Add(banktransferstatus);
        }

        public void Update(BankTransferStatusDto banktransferstatusDto)
        {
            var banktransferstatus = new BankTransferStatus
            {
                Id = banktransferstatusDto.Id,
                // Add other properties here
            };
            _Repository.Update(banktransferstatus);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
