using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    public interface IAppVariables
    {
        IEnumerable<int> PolygonRadiuses { get; set; }
        int GraphicCount { get; set; } //android preload işlemleri için
    }
}
