using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class InvoicesValidator:AbstractValidator<Invoices>
    {
        public InvoicesValidator()
        {
            RuleFor(x => x.InvoiceNr).Length(4).WithMessage("Maximum 4 reqem ola biler");
        }   
    }
}
