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
    public class VoicesManager : IVoicesService
    {
        IVoicesDAL _voicesDAL;

        public VoicesManager(IVoicesDAL voicesDAL)
        {
            _voicesDAL = voicesDAL;
        }

        public List<Invoices> GetList()
        {
            return _voicesDAL.GetListAll();
        }

        public void TAdd(Invoices t)
        {
            _voicesDAL.Insert(t);
        }

        public void TDelete(Invoices t)
        {
            _voicesDAL.Delete(t);
        }

        public Invoices TGetByID(int id)
        {
            return _voicesDAL.GetByID(id);
        }

        public void TUpdate(Invoices t)
        {
            _voicesDAL.Update(t);
        }
    }
}
