using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Sistemde bir login sistemi yok.
    /// Kullanıcı telefon bazında saklanıp, bu ID bilgisi ile kayıtlı işlemler yapabilecek.
    /// </summary>
    public interface IUser
    {
        int ID { get; set; }
        string UserID { get; set; }
        DateTime AddedDate { get; set; }
    }
}
