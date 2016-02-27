using TakeALook.Model;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace TakeALook.Repository
{
    /// <summary>
    /// CRUD işlemlerinde kullanılacak GenericRepository
    /// GenericRepositorynin yetmediği yerde custom işlemlerin yapıldığı repositoryler yazılabilir.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> 
        where T : DBObjectBase
    {
        private readonly ICustomDBContext m_Context;
        private IDbSet<T> m_Entities;
        private string m_ErrorMessage;

        private IDbSet<T> Entities
        {
            get
            {
                if (m_Entities == null)
                {
                    m_Entities = m_Context.Set<T>();
                }
                return m_Entities;
            }
        }
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Farklı contextler verilerek farklı dblere yönlendirilebilir</param>
        public GenericRepository(ICustomDBContext context) 
        {
            this.m_Context = context;
        }

        public T Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
                this.m_Context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        m_ErrorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(m_ErrorMessage, dbEx);
            }
        }

        public T Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Attach(entity);
                this.m_Context.Entry(entity).State = EntityState.Modified;
                if (this.m_Context.Entry(entity).Property("AddedDate") != null)
                {
                    this.m_Context.Entry(entity).Property("AddedDate").IsModified = false;
                }
                this.m_Context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        m_ErrorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                throw new Exception(m_ErrorMessage, dbEx);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                this.m_Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        m_ErrorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw new Exception(m_ErrorMessage, dbEx);
            }
        }

        public void Delete(Expression<Func<T, bool>> whereCondition)
        {
            IEnumerable<T> objects = this.Entities.Where<T>(whereCondition).AsEnumerable();
            foreach (T obj in objects)
                this.Entities.Remove(obj);
            this.m_Context.SaveChanges();
        }

        public T GetById(int id)
        {
            return this.Entities.Find(id);
        }

        public T Get(Expression<Func<T, bool>> whereCondition)
        {
            return this.Entities.Where(whereCondition).FirstOrDefault<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.Entities.ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> whereCondition)
        {
            return this.Entities.Where(whereCondition).ToList();
        }

        /// <summary>
        /// Üst katmanlarda tabloyu alıp, üzerinde expressionlar çalıştırılmak istenirse diye açıldı.
        /// </summary>
        public IQueryable<T> GetTable
        {
            get
            {
                return this.Entities;
            }
        }
    }
}
