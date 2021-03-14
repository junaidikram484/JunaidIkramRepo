using FiledWebApi.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiledWebApi.Models
{
    public class PaymentsModel
    {
        [Required]
        [RegularExpression("^[0-9]{16}$", ErrorMessage ="Invalid Credit Card Number")]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DateLessThanOrEqualToToday]
        public DateTime ExpirationDate { get; set; }
        [RegularExpression("[0-9]{3}",ErrorMessage ="Entered Security Code is wrong")]
        public string SecurityCode { get; set; }
        [Required]
        [RegularExpression(@"\d*(?:\.\d+)?",ErrorMessage ="Invalid Amount")]
        public decimal Amount { get; set; }
    }
}
