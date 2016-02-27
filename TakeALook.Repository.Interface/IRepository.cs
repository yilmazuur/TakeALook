using TakeALook.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TakeALook.Repository.Interface
{
    /// <summary>
    /// Repositorylerin hepsi bu interfaceten türetilmelidir.
    /// UnitOfWork bu interface tipindeki objelere dağılım yapacaktır.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : DBObjectBase
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> whereCondition);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> whereCondition);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> whereCondition);
    }
}
