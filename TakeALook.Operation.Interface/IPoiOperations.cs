using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IPoiOperations : IDisposable
    {
        IEnumerable<IPoi> GetPois();
        IEnumerable<IPoi> GetPois(string tableName);
        IEnumerable<IPoi> GetPoisInRectangle(double minX, double maxX, double minY, double maxY);
        IPoi GetPoi(int id);
        IPoi CreatePoi(IPoi poi);
        IPoi UpdatePoi(IPoi poi);
        void DeletePoi(IPoi poi);
        void DeletePoisByID(List<int> IDs);
    }
}
