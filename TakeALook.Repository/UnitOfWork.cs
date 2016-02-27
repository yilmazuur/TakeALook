using TakeALook.Model;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;

namespace TakeALook.Repository
{
    /// <summary>
    /// Repositoryler arasında dağıtım yapacak olan class(Unit Of Work Pattern)
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICustomDBContext m_Context;
        private Dictionary<string, object> m_Repositories;
        private DBContextCreationOptions m_CreationOption;
        private bool m_Disposed;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entityName">Verilen entity adı web.configdeki connStr ile aynı olmalı</param>
        /// <param name="creationOption">Hangi tipte context yaratılacağına karar vermek amaçlı</param>
        public UnitOfWork(DBContextCreationOptions creationOption)
        {
            this.m_CreationOption = creationOption;
            if (creationOption == m_CreationOption)
            {
                this.m_Context = new TakeALookDBContext();
            }
            else
            {
                throw new NotImplementedException("DBContextCreationOptions hatası");
            }
        }

        /// <summary>
        /// Context içeren bir obje olduğu için dispose edilebilmeli
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Context dispose
        /// </summary>
        public virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    this.m_Context.Dispose();
                }
            }
            m_Disposed = true;
        }

        /// <summary>
        /// Repositoryleri oluşturduğumuz method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : DBObjectBase
        {
            if (this.m_Repositories == null)
            {
                this.m_Repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!this.m_Repositories.ContainsKey(type))
            {
                Type repositoryType = null;
                if(m_CreationOption == DBContextCreationOptions.TakeALookDBContext)
                    repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.m_Context);
                this.m_Repositories.Add(type, repositoryInstance);
            }
            return (IRepository<T>)this.m_Repositories[type];
        }
    }

    /// <summary>
    /// Verilen bilgiye göre oluşturulacak repository ve context bilgisi değişir.
    /// </summary>
    public enum DBContextCreationOptions
    { 
        TakeALookDBContext
    }
}
