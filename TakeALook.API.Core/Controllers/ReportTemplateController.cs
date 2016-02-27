using TakeALook.Model;
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
    /// Report Template servisi
    /// </summary>
    public class ReportTemplateController : ApiController
    {
        private IReportTemplateOperations m_ReportTemplateOperations;

        /// <summary>
        /// Ctor    
        /// </summary>
        public ReportTemplateController() 
        {
            m_ReportTemplateOperations = new ReportTemplateOperations();
        }

        /// <summary>
        /// Her işlem sonrası otomatik çalışır
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            m_ReportTemplateOperations.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Rapor taslağını döner
        /// </summary>
        /// <returns>Rapor Taslağı</returns>
        public ServiceResponse Get()
        {
            //return new ServiceResponse("Rapor taslağını dönemedik",
            //    delegate()
            //    {
            //        return m_ReportTemplateOperations.GetTemplate();
            //    });
            return null;
        }
    }
}
