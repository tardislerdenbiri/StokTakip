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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetFirmalarHistoryView(int id)
        {
            return _orderDal.GetListByFilter(x => x.CompanyID == id);
        }

        public void TAdd(Order t)
        {
            _orderDal.Insert(t);
        }

        public void TDelete(Order t)
        {
            _orderDal.Delete(t);
        }

        public Order TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public Order TGetID(int id)
        {
            return _orderDal.GetID(x => x.OrderID == id);
        }

        public List<Order> TGetList()
        {
            return _orderDal.GetList();
        }

        public void TUpdate(Order t)
        {
            _orderDal.Update(t);
        }
    }
}
