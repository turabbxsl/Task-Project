using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Invoices
    {

        [Key]
        public int InvoicesID { get; set; }

        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("DueDate")]
        public DateTime DueDate { get; set; }

        [DisplayName("Invoice Number")]
        public string InvoiceNr { get; set; }

        [DisplayName("Order Number")]
        public int OrderNr { get; set; }


    }
}
