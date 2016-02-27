using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using TakeALook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation
{
    public class ReportOperations : OperationsBase, IReportOperations
    {
        IUserControlOperations m_LoadControl;

        /// <summary>
        /// Ctor
        /// </summary>
        public ReportOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_LoadControl = new UserControlOperations();
        }

        /// <summary>
        /// Rapor üretimi
        /// Karışıklığı önlemek ve güvenlik için yoğun miktardaki business kodu silindi.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="lon"></param>
        /// <param name="lat"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public IReportResult GenerateReport(IReportTemplate template, double lon, double lat, double radius)
        {
            return new ReportResult();
        }
    }
}
