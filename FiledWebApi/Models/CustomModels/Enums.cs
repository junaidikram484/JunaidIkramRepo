using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models.CustomModels
{
    public class Enums
    {
        public enum PaymentStatus
        {
            pending = 1,
            processed,
            failed
        }
    }
}
