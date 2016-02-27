using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    public interface INameValueDemogColumn
    {
        int ID { get; set; }
        //grup adı kullanıcıya gösterilecek custom bir isim, farklı farklı demog gruplardan veri seçilebilir. 
        //dolayısıyla commondaki demografik alanlarımızın grubu değil.
        string GroupName { get; set; }
        int DemogColumnOrder { get; set; }
        string DemogColumnName { get; set; }
        string UserFriendlyDemogColumnName { get; set; }
    }
}
