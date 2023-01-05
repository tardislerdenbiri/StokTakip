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
    public class HistoryManager : IHistoryService
    {
        IHistoryDal _historyDal;

        public HistoryManager(IHistoryDal historyDal)
        {
            _historyDal = historyDal;
        }

        public List<History> GetExcelList(int id)
        {
            return _historyDal.GetListByFilter(x => x.OrderID == id);
        }

        public List<History> GetListSiparisHistoryID(int id)
        {
            return _historyDal.GetListByFilter(x => x.OrderID == id);
        }

        public void TAdd(History t)
        {
            _historyDal.Insert(t);
        }

        public void TDelete(History t)
        {
            _historyDal.Delete(t);
        }

        public History TGetByID(int id)
        {
            return _historyDal.GetByID(id);
        }

        public History TGetID(int id)
        {
            return _historyDal.GetID(x => x.HistoryID == id);
        }

        public List<History> TGetList()
        {
            return _historyDal.GetList();
        }

        public void TUpdate(History t)
        {
            _historyDal.Update(t);
        }
    }
}
