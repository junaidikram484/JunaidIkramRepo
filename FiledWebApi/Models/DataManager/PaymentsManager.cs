using FiledWebApi.Models.DbModels;
using FiledWebApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.DataManager
{
    public class PaymentsManager : IDataRepository<Payments>
    {
        readonly PaymentsContext _context;
        public PaymentsManager(PaymentsContext context)
        {
            _context = context;
        }
        public Payments Get(int ID)
        {
            return _context.Payments
                  .FirstOrDefault(x => x.PaymentID == ID);
        }
        public Payments Get(Payments payment)
        {
            return _context.Payments
                  .FirstOrDefault(x => x.CreditCardNumber == payment.CreditCardNumber 
                  && x.CardHolder == payment.CardHolder 
                  && x.ExpirationDate == payment.ExpirationDate);
        }
        public void Add(Payments entity)
        {
            _context.Payments.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Payments payment, Payments entity)
        {
            payment.CardHolder = entity.CardHolder;
            payment.CreditCardNumber= entity.CreditCardNumber;
            payment.ExpirationDate = entity.ExpirationDate;
            payment.SecurityCode= entity.SecurityCode;
            payment.Amount = entity.Amount;
            payment.PaymentStatusID = entity.PaymentStatusID;
            payment.UpdatedDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
