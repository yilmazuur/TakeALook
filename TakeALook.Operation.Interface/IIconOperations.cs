using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IIconOperations : IDisposable
    {
        IEnumerable<IIcon> GetIcons();
        IEnumerable<IIcon> GetIcons(string title);
        IIcon GetIcon(int id);
        IIcon CreateIcon(IIcon icon);
        IIcon UpdateIcon(IIcon icon);
        void DeleteIcon(IIcon icon);
        void DeleteIconsByID(List<int> IDs);
    }
}
