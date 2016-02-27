using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using TakeALook.Repository;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation
{
    public class PolygonRadiusOperations : OperationsBase, IPolygonRadiusOperations
    {
        private IRepository<PolygonRadius> m_PolygonRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        public PolygonRadiusOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_PolygonRepository = m_UnitOfWork.Repository<PolygonRadius>();
        }

        /// <summary>
        /// Uygulama içerisinden atılabilecek buffer değerleri
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPolygonRadius> GetRadiuses()
        {
            return m_PolygonRepository.GetAll();
        }
    }
}
