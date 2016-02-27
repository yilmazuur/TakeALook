using TakeALook.Model;
using TakeALook.Operation;
using TakeALook.Operation.Interface;
using System.Web.Http;

namespace TakeALook.API.Core.Controllers
{
    /// <summary>
    /// KendoUI controllerini dönen servis
    /// </summary>
    public class UserControlController : ApiController
    {
        private IUserControlOperations m_UserControlOperations;
        
        /// <summary>
        /// Ctor
        /// </summary>
        public UserControlController() 
        {
            m_UserControlOperations = new UserControlOperations();
        }

        /// <summary>
        /// KendoUI HTML/js elementlerini döner
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>Name of control string olarak controlün adıdır ve input controlü besleyecek verilerdir</remarks>
        public ServiceResponse Post([FromBody]UserControlRequest request)
        {
            //return new ServiceResponse("Kontrol getirilemedi",
            //    delegate()
            //    {
            //        return m_UserControlOperations.LoadUserControl(request);
            //    });
            return null;
        }
    }
}
