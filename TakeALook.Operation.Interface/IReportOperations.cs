using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IReportOperations : IDisposable
    {
        IReportResult GenerateReport(IReportTemplate template, double lon, double lat, double radius);
    }
}
