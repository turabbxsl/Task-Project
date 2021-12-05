using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class LoanValidator: AbstractValidator<Loan>
    {
        public LoanValidator()
        {

            RuleFor(x => x.Amount).NotEmpty().WithMessage("Bu sahe mecburidir");
            RuleFor(x => x.Amount).GreaterThan(100).WithMessage("100-den boyuk olmalidir");
            RuleFor(x => x.Amount).LessThan(5000).WithMessage("5000-den kicik olmalidir");
            RuleFor(x => x.LoanPeriod).GreaterThan(3).WithMessage("3-den boyuk olmalidir");
            RuleFor(x => x.LoanPeriod).LessThan(24).WithMessage("24-den kicik olmalidir");

        }
    }
}
