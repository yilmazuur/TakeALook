using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Kullanıcının attığı pin ve not
    /// </summary>
    public interface IPinNote
    {
        int ID { get; set; }
        string UserID { get; set; }
        double Longitude { get; set; }
        double Latitude { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Note { get; set; }
        DateTime AddedDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
