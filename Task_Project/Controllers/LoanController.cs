using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Project.Controllers
{
    public class LoanController : Controller
    {

        LoanManager lm = new LoanManager(new EFLoanRepository());

        public ActionResult Index()
        {
            var values = lm.GetLoanListWithClient().OrderByDescending(x=>x.Amount);
            return View(values);
        }

        [HttpGet]
        public IActionResult LoanDetails(int id)
        {
            var value = lm.GetLoanByIDWithClient(id);

            var amount = value.Amount;

            return View(value);
        }

       

        [HttpGet]
        public IActionResult LoanAdd()
        {
            ClientManager cm = new ClientManager(new EFClientRepository());
            List<SelectListItem> clients = (from x in cm.GetList()
                                               select new SelectListItem()
                                               {
                                                   Text = x.Name,
                                                   Value = x.ClientID.ToString()
                                               }
                                               ).ToList();

            ViewBag.clients = clients;

            return View();
        }

        [HttpPost]
        public IActionResult LoanAdd(Loan loan,int ClientID)
        {

            LoanValidator wv = new LoanValidator();
            ValidationResult result = wv.Validate(loan);

            if (result.IsValid)
            {
                loan.ClientID = ClientID;
                loan.PayoutDate = DateTime.Now;
                lm.TAdd(loan);

                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            ClientManager cm = new ClientManager(new EFClientRepository());
            List<SelectListItem> clients = (from x in cm.GetList()
                                            select new SelectListItem()
                                            {
                                                Text = x.Name,
                                                Value = x.ClientID.ToString()
                                            }
                                               ).ToList();

            ViewBag.clients = clients;
            return View(loan);
        }


        public IActionResult DeleteLoan(int id)
        {
            var value = lm.TGetByID(id);
            lm.TDelete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditLoan(int id)
        {
            var blogvalue = lm.TGetByID(id);

            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditLoan(Loan loan)
        {
            lm.TUpdate(loan);
            return RedirectToAction("Index");
        }




    }
}
