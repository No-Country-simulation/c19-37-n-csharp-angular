using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _Repository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _Repository = paymentRepository;
        }

        public IEnumerable<PaymentDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new PaymentDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public PaymentDto GetById(int id)
        {
            var payment = _Repository.GetById(id);
            if (payment == null) return null;

            return new PaymentDto
            {
                Id = payment.Id,
                // Add other properties here
            };
        }

        public void Add(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                Id = paymentDto.Id,
                // Add other properties here
            };
            _Repository.Add(payment);
        }

        public void Update(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                Id = paymentDto.Id,
                // Add other properties here
            };
            _Repository.Update(payment);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
