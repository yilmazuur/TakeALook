using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Rapor hangi veriler olacağını söyleyen interface
    /// </summary>
    public interface IReportTemplate
    {
        IEnumerable<IReportChartComponent> ChartComponents { get; set; }
        IEnumerable<INameValueDemogColumn> NameValueComponents { get; set; }
    }
}
