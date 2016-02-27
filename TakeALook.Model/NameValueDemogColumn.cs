using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class NameValueDemogColumn : DBObjectBase, INameValueDemogColumn
    {
        public string GroupName { get; set; }
        public int DemogColumnOrder { get; set; }
        public string DemogColumnName { get; set; }
        public string UserFriendlyDemogColumnName { get; set; }
    }
}
