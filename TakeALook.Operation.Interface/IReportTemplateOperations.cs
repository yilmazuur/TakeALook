using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    /// <summary>
    /// Üretilecek raporun templateinin bileşenlerini aldığımız methodlar, kullanıcıdan kullanıcıya değişmez.
    /// </summary>
    public interface IReportTemplateOperations : IDisposable
    {
        IEnumerable<IChartDemogColumn> GetDemogColumns(int chartID);
        IEnumerable<IReportChartComponent> GetChartComponents();
        IReportTemplate GetTemplate();
        IEnumerable<INameValueDemogColumn> GetNameValueDemogColumns();
    }
}
