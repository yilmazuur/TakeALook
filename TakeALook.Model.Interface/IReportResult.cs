using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    /// <summary>
    /// Rapor sonuç verilerinin olacağı interface
    /// </summary>
    public interface IReportResult
    {
        List<IUserControlDto> Charts { get; set; }
        Dictionary<string, Dictionary<string, int>> NameValueResults { get; set; }  //Key=demog group, Value=demog columns ve values
        List<IPoi> Pois { get; set; }
    }
}
