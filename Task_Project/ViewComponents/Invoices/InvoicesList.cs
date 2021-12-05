using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Project.ViewComponents.Invoices
{
    public class InvoicesList: ViewComponent
    {
       VoicesManager vm = new VoicesManager(new EFVoicesRepository());
        public IViewComponentResult Invoke()
        {
            var values = vm.GetList().OrderBy(x=>x.OrderNr);

            var sum = values.Sum(x=>x.Amount);

            ViewBag.total = sum;

            return View(values);
        }
    }
}
