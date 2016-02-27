using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class PolygonRadius : DBObjectBase, IPolygonRadius
    {
        public int Radius { get; set; }
    }
}
