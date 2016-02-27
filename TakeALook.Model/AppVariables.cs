using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    /// <summary>
    /// Mobile dönülecek servis, o yüzden PolygonRadises obje olarak değil de list<int> olarak dönüldü
    /// </summary>
    public class AppVariables : IAppVariables
    {
        public IEnumerable<int> PolygonRadiuses { get; set; }
        //Kaç grafik olacağı bilgisi önden androide lazım. Webview optimizasyonu amaçlı
        public int GraphicCount { get; set; }
    }
}
