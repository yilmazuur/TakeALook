using TakeALook.Model.Interface;
using System.Collections.Generic;

namespace TakeALook.Model
{
    public class ReportResult : IReportResult
    {
        public List<IUserControlDto> Charts { get; set; }
        public Dictionary<string, Dictionary<string, int>> NameValueResults { get; set; }
        public List<IPoi> Pois { get; set; }
    }
}
