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
    /// Icon işlemleri
    /// </summary>
    public class IconOperations : OperationsBase, IIconOperations
    {
        private IRepository<Icon> m_IconRepository;

        /// <summary>
        /// Ctor, OperationBasede unitOfWorkü set eder
        /// </summary>
        public IconOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_IconRepository = m_UnitOfWork.Repository<Icon>();
        }

        public IEnumerable<IIcon> GetIcons()
        {
            return m_IconRepository.GetAll();
        }

        public IEnumerable<IIcon> GetIcons(string title)
        {
            return m_IconRepository.GetMany(x => x.Title.Contains(title));
        }

        public IIcon GetIcon(int id)
        {
            return m_IconRepository.GetById(id);
        }

        public IIcon CreateIcon(IIcon icon)
        {
            return m_IconRepository.Add(icon as Icon);
        }

        public IIcon UpdateIcon(IIcon icon)
        {
            return m_IconRepository.Update(icon as Icon);
        }

        public void DeleteIcon(IIcon icon)
        {
            m_IconRepository.Delete(icon as Icon);
        }

        public void DeleteIconsByID(List<int> IDs)
        {
            m_IconRepository.Delete(x => IDs.Contains(x.ID));
        }
    }
}
