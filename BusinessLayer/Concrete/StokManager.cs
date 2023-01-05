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
    public class StokManager : IStokService
    {
        IStokDal _stokDal;

        public StokManager(IStokDal stokDal)
        {
            _stokDal = stokDal;
        }

        public List<Stok> GetListSiparisView(int id)
        {
            return _stokDal.GetListByFilter(x=>x.OrderID == id);
        }

        public List<Stok> GetListUrunDetayDepoAdet(int id)
        {
            return _stokDal.GetListByFilter(x => x.ProductsID == id);
        }

        public List<Stok> GetStokSn(string sn)
        {
            return _stokDal.GetListByFilter(x => x.StokSn == sn);
        }

        public List<Stok> GetUrunlerStok(int id)
        {
            return _stokDal.GetListByFilter(x => x.ProductsID == id);
        }

        public List<Stok> OrderDeleteGetStokProductid(int id)
        {
            return _stokDal.GetListByFilter(x => x.OrderID == id);
        }

        public void TAdd(Stok t)
        {
            _stokDal.Insert(t);
        }

        public void TDelete(Stok t)
        {
            _stokDal.Delete(t);
        }

        public Stok TGetByID(int id)
        {
            return _stokDal.GetByID(id);
        }

        public Stok TGetID(int id)
        {
            return _stokDal.GetID(x => x.StokID == id);
        }

        public List<Stok> TGetList()
        {
            return _stokDal.GetList();
        }

        public void TUpdate(Stok t)
        {
            _stokDal.Update(t);
        }

    }
}
