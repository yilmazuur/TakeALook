using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class ReportTemplate : IReportTemplate
    {
        public IEnumerable<IReportChartComponent> ChartComponents { get; set; }
        public IEnumerable<INameValueDemogColumn> NameValueComponents { get; set; }
    }
}
