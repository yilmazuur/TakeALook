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
    /// User Servisi
    /// </summary>
    public class InitController : ApiController
    {
        private IUserOperations m_UserOperations;
        private IPolygonRadiusOperations m_PolygonRadiusOperations;
        private IReportTemplateOperations m_ReportTemplateOperations;

        /// <summary>
        /// Ctor    
        /// </summary>
        public InitController() 
        {
            m_UserOperations = new UserOperations();
            m_PolygonRadiusOperations = new PolygonRadiusOperations();
            m_ReportTemplateOperations = new ReportTemplateOperations();
        }

        /// <summary>
        /// Her işlem sonrası otomatik çalışır
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            m_UserOperations.Dispose();
            m_PolygonRadiusOperations.Dispose();
            m_ReportTemplateOperations.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Kullanıcı var mı diye kontrol eder, yoksa create eder ve uygulama bileşenlerini döner
        /// </summary>
        /// <param name="value">User objesi</param>
        /// <returns>User objesi</returns>
        public ServiceResponse Post([FromBody]User user)
        {
            return new ServiceResponse("Oturum açılamadı",
                delegate()
                {
                    m_UserOperations.CreateUser(user);
                    return new AppVariables() { 
                        GraphicCount = m_ReportTemplateOperations.GetChartComponents().Count(),
                        PolygonRadiuses = m_PolygonRadiusOperations.GetRadiuses().Select(x=> x.Radius)
                    };
                });
        }
    }
}
