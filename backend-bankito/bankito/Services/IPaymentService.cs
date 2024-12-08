using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDto> GetAll();
        PaymentDto GetById(int id);
        void Add(PaymentDto paymentDto);
        void Update(PaymentDto paymentDto);
        void Delete(int id);
    }
}
