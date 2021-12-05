using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface ILoanDAL: IGenericDal<Loan>
    {
        List<Loan> GetLoanListWithClient();

        public Loan GetLoanByIDWithClient(int id);
    }
}
