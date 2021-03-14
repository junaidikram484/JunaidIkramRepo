using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.PaymentProcessing
{
    interface ICheapPaymentGateway
    {
        bool ProcessPaymentCheaply (PaymentsModel model);
    }
}
