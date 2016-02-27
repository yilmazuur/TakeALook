using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    /// <summary>
    /// Sistemde bir login sistemi yok.
    /// Kullanıcı telefon bazında saklanıp, bu ID bilgisi ile kayıtlı işlemler yapabilecek.
    /// </summary>
    public class User : DBObjectBase, IUser
    {
        public string UserID { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
