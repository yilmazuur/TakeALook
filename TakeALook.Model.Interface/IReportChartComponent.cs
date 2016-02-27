using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Rapor templateinde kullanılacak bileşen interfacei
    /// </summary>
    public interface IReportChartComponent
    {
        int ID { get; set; }
        int ShowingTab { get; set; }
        IEnumerable<IChartDemogColumn> DemogColumns { get; set; }
        int? DemogColumnInTitleColumnOrder { get; set; }
        string DemogColumnInTitle { get; set; } //Örn: kadın-erkek nüfus grafiği için total nüfus titleda gösterilecek
        string ChartType { get; set; }
        string UserFriendlyDemogColumnInTitle { get; set; }
    }
}
