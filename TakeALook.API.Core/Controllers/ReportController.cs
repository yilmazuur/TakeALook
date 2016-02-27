using TakeALook.Model.Interface;
using TakeALook.Operation;
using TakeALook.Operation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TakeALook.API.Core.Controllers
{
    /// <summary>
    /// Rapor üretimi
    /// </summary>
    public class ReportController : ApiController
    {
        private IReportOperations m_ReportOperations;
        private IReportTemplateOperations m_ReportTemplateOperations;

        /// <summary>
        /// Ctor    
        /// </summary>
        public ReportController()
        {
            m_ReportOperations = new ReportOperations();
            m_ReportTemplateOperations = new ReportTemplateOperations();
        }

        /// <summary>
        /// Her işlem sonrası otomatik çalışır
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            m_ReportOperations.Dispose();
            m_ReportTemplateOperations.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Rapor taslağını döner
        /// </summary>
        /// <returns>Rapor Taslağı</returns>
        [Route("api/v1/Report/Generate")]
        public ServiceResponse Get(double lon, double lat, double radius)
        {
            //return new ServiceResponse("Rapor üretilemedi",
            //    delegate()
            //    {
            //        return m_ReportOperations.GenerateReport(m_ReportTemplateOperations.GetTemplate(), lon, lat, radius);
            //    });
            return null;
        }
    }
}
