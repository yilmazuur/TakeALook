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
    /// <summary>
    /// Poi işlemleri
    /// </summary>
    public class PoiOperations : OperationsBase, IPoiOperations
    {
        private IRepository<Poi> m_PoiRepository;

        /// <summary>
        /// Ctor, OperationBasede unitOfWorkü set eder
        /// </summary>
        public PoiOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_PoiRepository = m_UnitOfWork.Repository<Poi>();
        }

        public IEnumerable<IPoi> GetPois()
        {
            return m_PoiRepository.GetAll();
        }

        public IEnumerable<IPoi> GetPois(string tableName)
        {
            return m_PoiRepository.GetMany(x => x.TableName.Contains(tableName));
        }

        public IEnumerable<IPoi> GetPoisInRectangle(double minX, double maxX, double minY, double maxY)
        {
            return m_PoiRepository.GetMany(x => x.Longitude >= minX && x.Longitude <= maxX && x.Latitude >= minY && x.Latitude <= maxY);
        }

        public IPoi GetPoi(int id)
        {
            return m_PoiRepository.GetById(id);
        }

        public IPoi CreatePoi(IPoi poi)
        {
            poi.AddedDate = DateTime.Now;
            poi.ModifiedDate = DateTime.Now;
            return m_PoiRepository.Add(poi as Poi);
        }

        public IPoi UpdatePoi(IPoi poi)
        {
            poi.ModifiedDate = DateTime.Now;
            return m_PoiRepository.Update(poi as Poi);
        }

        public void DeletePoi(IPoi poi)
        {
            m_PoiRepository.Delete(poi as Poi);
        }

        public void DeletePoisByID(List<int> IDs) 
        {
            m_PoiRepository.Delete(x => IDs.Contains(x.ID));
        }
    }
}
