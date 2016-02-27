using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface ICategoryOperations : IDisposable
    {
        IEnumerable<ICategory> GetCategories();
        ICategory GetCategory(string name);
        IEnumerable<ICategory> GetCategoriesByID(List<int> IDs);
        ICategory GetCategory(int id);
        ICategory CreateCategory(ICategory category);
        ICategory UpdateCategory(ICategory category);
        void DeleteCategory(ICategory category);
        void DeleteCategoriesByID(List<int> IDs);
    }
}
