using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Interest Rate")]
        public decimal InterestRate { get; set; }

        [DisplayName("Loan Period")]
        public int LoanPeriod { get; set; }

        [DisplayName("Payout Date")]
        public DateTime PayoutDate { get; set; }

        [DisplayName("Client")]
        public int ClientID { get; set; }
        public Client Client { get; set; }

    }
}
