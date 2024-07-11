using System.Collections.Generic;
using System.Linq;
using bankito.Models;

namespace bankito.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly List<Payment> _s = new List<Payment>();

        public IEnumerable<Payment> GetAll() => _s;

        public Payment GetById(int id) => _s.FirstOrDefault(p => p.Id == id);

        public void Add(Payment payment) => _s.Add(payment);

        public void Update(Payment payment)
        {
            var index = _s.FindIndex(p => p.Id == payment.Id);
            if (index >= 0) _s[index] = payment;
        }

        public void Delete(int id)
        {
            var payment = _s.FirstOrDefault(p => p.Id == id);
            if (payment != null) _s.Remove(payment);
        }
    }
}
