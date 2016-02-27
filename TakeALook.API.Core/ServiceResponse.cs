using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.API.Core
{
    /// <summary>
    /// ServiceCallarda dönülecek tek tip response
    /// </summary>
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public ServiceException Error { get; set; }
        public string UserFriendlyErrorMessage { get; set; }
        public string UserFriendlyDataEmptyMessage { get; set; }
        public object Data { get; set; }

        /// <summary>
        /// Ctor
        /// </summary>
        public ServiceResponse() { }

        /// <summary>
        /// Tüm servislerin outputunda gönderilecek class bu olduğu için atamaları merkezileştirildi.
        /// </summary>
        /// <param name="userFriendlyErrorMessage"></param>
        /// <param name="method"></param>
        public ServiceResponse(string userFriendlyErrorMessage, Func<object> method, string userFriendlyDataEmptyMessage = "") 
        {
            try
            {
                this.IsSuccess = true;
                this.Data = method();
                if (!string.IsNullOrEmpty(userFriendlyDataEmptyMessage) && this.Data == null)
                {
                    this.UserFriendlyDataEmptyMessage = userFriendlyDataEmptyMessage;
                }
            }
            catch (Exception ex)
            {
                this.IsSuccess = false;
                this.Error = new ServiceException(ex.Message, ex.ToString());
                this.UserFriendlyErrorMessage = userFriendlyErrorMessage;
            }
        }

    }

    /// <summary>
    /// Servicete bir hata alınırsa dönülecek exception
    /// </summary>
    public class ServiceException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public ServiceException() { }
        public ServiceException(string message, string stackTrace) 
        {
            this.Message = Message;
            this.StackTrace = stackTrace;
        }
    }
}
