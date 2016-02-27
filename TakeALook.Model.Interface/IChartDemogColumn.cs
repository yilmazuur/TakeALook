using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    public interface IChartDemogColumn
    {
        int ID { get; set; }
        int ChartID { get; set; }
        int ColumnOrder { get; set; }
        string ColumnName { get; set; }
        string UserFriendlyName { get; set; }
        string Color { get; set; }
    }
}
