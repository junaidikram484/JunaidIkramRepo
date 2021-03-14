using FiledWebApi.Models;
using FiledWebApi.Models.CustomModels;
using FiledWebApi.Models.DataManager;
using FiledWebApi.Models.DbModels;
using FiledWebApi.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FiledWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IDataRepository<Payments> _repository;
        public PaymentsController(IDataRepository<Payments> paymentRepository)
        {
            _repository = paymentRepository;
        }
        [HttpPost]
        public HttpResponseMessage ProcessPayment([FromForm] PaymentsModel payment) //created custom model to apply validation on the properties.
        {
            var response = new HttpResponseMessage();
            try
            {
                var paymentObject = new Payments
                {
                    CardHolder = payment.CardHolder,
                    CreditCardNumber = payment.CreditCardNumber,
                    ExpirationDate = payment.ExpirationDate,
                    SecurityCode = payment.SecurityCode,
                    Amount = payment.Amount,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    IsActive = true,
                    PaymentStatusID = (int)Enums.PaymentStatus.pending,
                    RetryCounts = 0
                }; // Binding values to db entity model.
                Task.Run(() => _repository.Add(paymentObject)).Wait();

                if (payment.Amount < 20)
                {
                    // process payment from ICheapPayment
                    //if response == true
                    //   paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.processed
                    //else
                    //   paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.failed
                }
                else if (payment.Amount >= 21 && payment.Amount <= 500)
                {
                    //process payment through IExpensivePayment 
                    //if response == true
                    //   paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.processed
                    //else 
                    //   process payment from ICheapPayment
                    //   if response == true
                    //      paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.processed
                    //   else
                    //      paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.failed
                }
                else
                {
                    //int retry = 0;
                    //Process payment through premium services
                    //if response == true{
                    //   paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.processed
                    //   retry++;
                    //}
                    //else 
                    //    bool ispaymentPassed = false;
                    //    while(retry < 3)
                    //    {
                    //       Retry Processing from Premium service
                    //       if(response == true){
                    //          paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.processed
                    //          ispaymentPassed = true;
                    //       }else{
                    //          retry ++;
                    //       }
                    //    }
                    //    if(ispaymentPassed == false){
                    //      paymentObject.PaymentStatusID = (int)Enums.PaymentStatus.failed
                    //    }

                }
                paymentObject.PaymentStatusID = 3;
                var lastPayment = Task.Run(() => _repository.Get(paymentObject.PaymentID)).Result;
                Task.Run(() => _repository.Update(lastPayment, paymentObject)).Wait();

                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = ex.ToString()
                };
            }
            return response;
        }
    }
}
