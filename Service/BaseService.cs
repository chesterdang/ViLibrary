using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Service
{
    public class BaseService<T, V> where T : DataAccess<V> where V : class
    {
        private T _dao;
        public BaseService(T dao)
        {
            _dao = dao;
        }
        public IEnumerable<V> GetAll()
        {
            return _dao.GetAll();
        }

        public V? Get(Expression<Func<V, bool>> filter)
        {
            return _dao.Get(filter);
        }
        public void Add(V v)
        {
            _dao.Add(v);
        }

        public void Delete(V v)
        {
            _dao.Remove(v);
        }
    }
}
