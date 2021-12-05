using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Project.Controllers
{
    public class InvoicesController : Controller
    {
        VoicesManager vm = new VoicesManager(new EFVoicesRepository());
        public PartialViewResult Index()
        {
            var values = vm.GetList();

            return PartialView(values);
        }

        public IActionResult CalculateInvoices(Loan loan)
        {
            var values = vm.GetList();

            var sortInvoiceNr = values.OrderByDescending(x=>x.InvoiceNr);
            var sortID = values.OrderByDescending(x=>x.InvoicesID);

            var selectInvoice = sortInvoiceNr.FirstOrDefault();
            var selectID = sortID.FirstOrDefault();

            string zeroAppEnd;

            if (Convert.ToInt32(selectInvoice.InvoiceNr) < 10)
            {
                zeroAppEnd = "000";
            }
            else if (Convert.ToInt32(selectInvoice.InvoiceNr) < 99)
            {
                zeroAppEnd = "00";
            }
            else if (Convert.ToInt32(selectInvoice.InvoiceNr) < 999)
            {
                zeroAppEnd = "0";
            }
            else
            {
                zeroAppEnd = "";
            }


            var invoice = Convert.ToInt32(selectInvoice.InvoiceNr) + 1;
            var ID = Convert.ToInt32(selectID.InvoicesID) + 1;
  
            if (ModelState.IsValid)
            {

                string sqlFormattedDate = loan.PayoutDate.Date.ToString("dd-MM-yyyy");

                var unpaidAmount = ((loan.LoanPeriod - invoice + 1) * loan.Amount) / invoice;

                Invoices invoices = new Invoices();

                invoices.DueDate = Convert.ToDateTime(sqlFormattedDate).AddMonths(1);
                invoices.InvoiceNr = zeroAppEnd + invoice.ToString();
                invoices.Amount = (loan.Amount / loan.LoanPeriod) + (unpaidAmount * loan.InterestRate);
                invoices.OrderNr = loan.LoanId;
                invoices.InvoicesID = ID;

                vm.TAdd(invoices);

                return RedirectToAction("LoanDetails", "Loan",new {id=loan.LoanId});
            }
            return View(loan);
           
        }



    }
}
