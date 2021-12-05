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
    public class ClientManager : IClientService
    {

        IClientDAL _clientDAL;

        public ClientManager(IClientDAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public List<Client> GetList()
        {
            return _clientDAL.GetListAll();
        }

        public void TAdd(Client t)
        {
            _clientDAL.Insert(t);
        }

        public void TDelete(Client t)
        {
            _clientDAL.Delete(t);
        }

        public Client TGetByID(int id)
        {
            return _clientDAL.GetByID(id);
        }

        public void TUpdate(Client t)
        {
            _clientDAL.Update(t);
        }
    }
}

