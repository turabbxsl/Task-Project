using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }

        [DisplayName("Client Name")]
        public string Name { get; set; }

        [DisplayName("Client Surname")]
        public string Surname { get; set; }

        [DisplayName("Telephone Number")]
        public string TelephoneNr { get; set; }

        public List<Loan> Loans { get; set; }
    }
}
