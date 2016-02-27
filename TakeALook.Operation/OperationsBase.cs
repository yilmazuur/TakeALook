using TakeALook.Repository;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation
{
    /// <summary>
    /// Tüm operation classlarında aşağıdaki işlemler aynı olacağı için bir base classa çıkarıldı
    /// </summary>
    public class OperationsBase
    {
        protected IUnitOfWork m_UnitOfWork;

        protected OperationsBase(DBContextCreationOptions option)
        {
            m_UnitOfWork = new UnitOfWork(option);
        }

        /// <summary>
        /// unitOfWork dispose
        /// </summary>
        public void Dispose()
        {
            m_UnitOfWork.Dispose();
        }
    }
}
