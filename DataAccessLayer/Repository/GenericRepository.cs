using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T t)
        {
            var deleteEntity = c.Entry(t);
            deleteEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public T GetID(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public List<T> GetListByFilter(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Insert(T t)
        {
            var insertEntity = c.Entry(t);
            insertEntity.State = EntityState.Added;
            c.SaveChanges();
            
        }

        public void Update(T t)
        {
            var updateEntity = c.Entry(t);
            updateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
