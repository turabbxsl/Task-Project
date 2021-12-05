using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFLoanRepository : GenericRepository<Loan>, ILoanDAL
    {
        public List<Loan> GetLoanListWithClient()
        {
            using (var c = new Context())
            {
                return c.Loans.Include(x => x.Client).ToList();
            };
        }

        public Loan GetLoanByIDWithClient(int id)
        {
            using (var c = new Context())
            {
                return c.Loans.Include(x => x.Client).Where(x => x.LoanId == id).FirstOrDefault();
            };
        }

    }
}
