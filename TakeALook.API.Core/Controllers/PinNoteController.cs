using TakeALook.Model;
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
    /// PinNote Servisi
    /// </summary>
    public class PinNoteController : ApiController
    {
        private IPinNoteOperations m_PinNoteOperations;

        /// <summary>
        /// Ctor
        /// </summary>
        public PinNoteController()
        {
            m_PinNoteOperations = new PinNoteOperations();
        }

        /// <summary>
        /// Her işlem sonrası otomatik çalışır
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) 
        {
            m_PinNoteOperations.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Tüm pin-not listesini getir
        /// </summary>
        /// <returns></returns>
        [Route("api/v1/PinNote/GetAll")]
        public ServiceResponse Get()
        {
            return new ServiceResponse("Pin notları getirilemedi",
                delegate()
                {
                    return m_PinNoteOperations.GetPinNotes();
                }
                ,"Pin bulunamadı");
        }

        /// <summary>
        /// İsminde verilen parametre geçen pin-not listesini getir
        /// </summary>
        /// <param name="param">PinNote Adı</param>
        /// <returns></returns>
        [Route("api/v1/PinNote/GetByName/{param}")]
        public ServiceResponse GetByName(string name)
        {
            return new ServiceResponse("Pin notları getirilemedi", 
               delegate()
               {
                   return m_PinNoteOperations.GetPinNotes(name);
               },
               "Pin bulunamadı");
        }

        /// <summary>
        /// Verilen kullanıcı bilgisine göre pin-not listesi getir
        /// </summary>
        /// <param name="param">Kullanıcı Adı</param>
        /// <returns></returns>
        [Route("api/v1/PinNote/GetByUser/{param}")]
        public ServiceResponse GetByUser(string userName)
        {
            return new ServiceResponse("Pin notları getirilemedi",
               delegate()
               {
                   return m_PinNoteOperations.GetPinNotesByUser(userName);
               }
               , "Pin bulunamadı");
        }

        /// <summary>
        /// Verilen id'e göre pin-not getir
        /// </summary>
        /// <param name="id">PinNote ID</param>
        /// <remarks>Özel bir not bulunmamaktadır.</remarks>
        public ServiceResponse Get(int id)
        {
            return new ServiceResponse("Pin notu getirilemedi", 
                delegate()
               {
                   return m_PinNoteOperations.GetPinNote(id);
               }
               , "Pin bulunamadı");
        }

        /// <summary>
        /// Pin-not oluşturur
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("api/v1/PinNote/Create")]
        public ServiceResponse PostToCreate([FromBody]PinNote value)
        {
            return new ServiceResponse("Pin notu kaydedilemedi",
               delegate()
               {
                   return m_PinNoteOperations.CreatePinNote(value);
               });
        }

        /// <summary>
        /// Eşleşen ID üzerinden pin-not update eder
        /// </summary>
        /// <param name="value">PinNote objesi</param>
        /// <returns></returns>
        [Route("api/v1/PinNote/Update")]
        public ServiceResponse PostToUpdate([FromBody]PinNote pinNote)
        {
            return new ServiceResponse("Pin notu güncellenemedi",
               delegate()
               {
                   return m_PinNoteOperations.UpdatePinNote(pinNote);
               });
        }

        /// <summary>
        /// Eşleşen id üzerinden pin-not siler
        /// </summary>
        /// <param name="id">PinNote ID</param>
        /// <returns></returns>
        public ServiceResponse Delete(int id)
        {
            ServiceResponse sr = new ServiceResponse();
            var pinNote = m_PinNoteOperations.GetPinNote(id);
            if (pinNote == null)
            {
                sr.UserFriendlyErrorMessage = "Silinecek pin notu bulunamadı";
                sr.UserFriendlyDataEmptyMessage = "Silinecek pin notu bulunamadı";
                sr.IsSuccess = false;
            }
            else
            {
                m_PinNoteOperations.DeletePinNote(pinNote);
                sr.IsSuccess = true;
            }
            return sr;
        }
    }
}
