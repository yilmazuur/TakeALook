using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Poi categorysi
    /// </summary>
    public interface ICategory
    {
        int ID { get; set; }
        string Name { get; set; }
        int IconID { get; set; }
        int ListOrder { get; set; }
        int RenderOrder { get; set; }
    }
}
