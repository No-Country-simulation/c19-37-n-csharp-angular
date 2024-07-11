using System.Collections.Generic;
using bankito.Models;

namespace bankito.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAll();
        Payment GetById(int id);
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(int id);
    }
}
