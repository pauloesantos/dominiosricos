using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payment;
        public Subscription(DateTime? expireDate)
        {
            Createdate = DateTime.Now;
            LastUpdatedate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payment = new List<Payment>();
        }

        public DateTime Createdate { get; private set; }
        public DateTime LastUpdatedate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get; private set; }

        public void AddPayment(Payment payment)
        {
            foreach (var pay in Payments)
            {
                _payment.Add(payment);
            }
        }

        public void Activate()
        {
            Active = true;
            LastUpdatedate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdatedate = DateTime.Now;
        }
    }
}