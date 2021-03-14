using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.PaymentProcessing
{
    public class StandardPaymentProcessing : ICheapPaymentGateway, IExpensivePaymentGateway
    {
        public bool ProcessPaymentCheaply(PaymentsModel model)
        {
            //we will perform processing here;
            return true;
        }

        public bool ProcessPaymentExpensively(PaymentsModel model)
        {
            //we will perform processing here;
            return true;
        }
    }
}
