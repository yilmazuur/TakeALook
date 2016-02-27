using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Haritada gösterilecek poi ikonları
    /// </summary>
    public interface IIcon
    {
        int ID { get; set; }
        string Title { get; set; }
        string URL { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}
