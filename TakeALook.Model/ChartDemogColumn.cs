using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class ChartDemogColumn: DBObjectBase, IChartDemogColumn
    {
        public int ChartID { get; set; }
        public int ColumnOrder { get; set; }
        public string ColumnName { get; set; }
        public string UserFriendlyName { get; set; }
        public string Color { get; set; }
    }
}
