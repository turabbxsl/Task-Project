using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoanManager : ILoanService
    {

        ILoanDAL _loanDal;

        public LoanManager(ILoanDAL aboutDal)
        {
            _loanDal = aboutDal;
        }

        public List<Loan> GetList()
        {
            return _loanDal.GetListAll();
        }

        public void TAdd(Loan t)
        {
           _loanDal.Insert(t);
        }

        public void TDelete(Loan t)
        {
            _loanDal.Delete(t);
        }

        public Loan TGetByID(int id)
        {
            return _loanDal.GetByID(id);
        }

        public void TUpdate(Loan t)
        {
            _loanDal.Update(t);
        }

        public List<Loan> GetLoanListWithClient()
        {
            return _loanDal.GetLoanListWithClient();
        }

        public Loan GetLoanByIDWithClient(int id)
        {
            return _loanDal.GetLoanByIDWithClient(id);
        }

    }
}
