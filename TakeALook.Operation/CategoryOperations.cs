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
    /// Category işlemleri
    /// </summary>
    public class CategoryOperations : OperationsBase, ICategoryOperations
    {
        private IRepository<Category> m_CategoryRepository;

        /// <summary>
        /// Ctor, OperationBasede unitOfWorkü set eder
        /// </summary>
        public CategoryOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_CategoryRepository = m_UnitOfWork.Repository<Category>();
        }

        public IEnumerable<ICategory> GetCategories()
        {
            return m_CategoryRepository.GetAll();
        }

        public ICategory GetCategory(string name)
        {
            return m_CategoryRepository.Get(x => x.Name == name);
        }

        public IEnumerable<ICategory> GetCategoriesByID(List<int> IDs)
        {
            return m_CategoryRepository.GetMany(x => IDs.Contains(x.ID));
        }

        public ICategory GetCategory(int id)
        {
            return m_CategoryRepository.GetById(id);
        }

        public ICategory CreateCategory(ICategory category)
        {
            return m_CategoryRepository.Add(category as Category);
        }

        public ICategory UpdateCategory(ICategory category)
        {
            return m_CategoryRepository.Update(category as Category);
        }

        public void DeleteCategory(ICategory category)
        {
            m_CategoryRepository.Delete(category as Category);
        }

        public void DeleteCategoriesByID(List<int> IDs)
        {
            m_CategoryRepository.Delete(x => IDs.Contains(x.ID));
        }
    }
}
