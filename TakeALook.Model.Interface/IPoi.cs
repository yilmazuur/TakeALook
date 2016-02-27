using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Sorgulama sırasında kullanılacak olan Poi
    /// </summary>
    public interface IPoi
    {
        int ID { get; set; }
        int CategoryID { get; set; }
        int ProvinceID { get; set; }
        int DistrictID { get; set; }
        int NeighborhoodID { get; set; }
        string TableName { get; set; }
        string CustomID { get; set; }
        double Longitude { get; set; }
        double Latitude { get; set; }
        string Address { get; set; }
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
