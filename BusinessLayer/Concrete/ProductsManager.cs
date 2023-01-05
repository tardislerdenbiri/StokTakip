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
    public class ProductsManager : IProductsService
    {
        IProductsDal _productsDal;

        public ProductsManager(IProductsDal productsDal)
        {
            _productsDal = productsDal;
        }

        public void TAdd(Products t)
        {
            _productsDal.Insert(t);
        }

        public void TDelete(Products t)
        {
            _productsDal.Delete(t);
        }

        public Products TGetByID(int id)
        {
            return _productsDal.GetByID(id);
        }

        public Products TGetID(int id)
        {
            return _productsDal.GetID(x=>x.ProductsID==id);
        }

        public List<Products> TGetList()
        {
            return _productsDal.GetList();
        }

        public void TUpdate(Products t)
        {
            _productsDal.Update(t);
        }
    }
}
