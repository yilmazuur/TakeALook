using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class ReportChartComponent : DBObjectBase, IReportChartComponent
    {
        public int ShowingTab { get; set; }
        public IEnumerable<IChartDemogColumn> DemogColumns { get; set; }
        public int? DemogColumnInTitleColumnOrder { get; set; }
        public string DemogColumnInTitle { get; set; }
        public string UserFriendlyDemogColumnInTitle { get; set; }
        public string ChartType { get; set; }
    }
}
