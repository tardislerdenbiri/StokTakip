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
    public class StoresManager : IStoresService
    {
        IStoresDal _storesDal;

        public StoresManager(IStoresDal storesDal)
        {
            _storesDal = storesDal;
        }

        public void TAdd(Stores t)
        {
            _storesDal.Insert(t);
        }

        public void TDelete(Stores t)
        {
            _storesDal.Delete(t);
        }

        public Stores TGetByID(int id)
        {
            return _storesDal.GetByID(id);
        }

        public Stores TGetID(int id)
        {
            return _storesDal.GetID(x=>x.StoresID==id);
        }

        public List<Stores> TGetList()
        {
            return _storesDal.GetList();
        }

        public void TUpdate(Stores t)
        {
            _storesDal.Update(t);
        }
    }
}
