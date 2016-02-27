using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using TakeALook.Repository.Interface;
using TakeALook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeALook.Model;

namespace TakeALook.Operation
{
    /// <summary>
    /// Pin ve not işlemlerinin operation methodları
    /// </summary>
    public class PinNoteOperations : OperationsBase, IPinNoteOperations
    {
        private IRepository<PinNote> m_PinNoteRepository;

        /// <summary>
        /// Ctor, OperationBasede unitOfWorkü set eder
        /// </summary>
        public PinNoteOperations()
            : base(DBContextCreationOptions.TakeALookDBContext)
        {
            m_PinNoteRepository = m_UnitOfWork.Repository<PinNote>();
        }

        /// <summary>
        /// Tüm PinNoteları döner
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPinNote> GetPinNotes()
        {
            return m_PinNoteRepository.GetAll();
        }

        /// <summary>
        /// İçinde gönderilen parametre geçen PinNoteları döner
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<IPinNote> GetPinNotes(string name)
        {
            return m_PinNoteRepository.GetMany(x => x.Name.Contains(name));
        }

        /// <summary>
        /// Bir kullanıcının tüm PinNotelarını döner
        /// </summary>
        /// <param name="userIdentifier"></param>
        /// <returns></returns>
        public IEnumerable<IPinNote> GetPinNotesByUser(string userIdentifier)
        {
            return m_PinNoteRepository.GetMany(x => x.UserID == userIdentifier);
        }

        /// <summary>
        /// Girilen id'nin karşılığındaki PinNoteu döner
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPinNote GetPinNote(int id)
        {
            return m_PinNoteRepository.GetById(id);
        }

        /// <summary>
        /// PinNote yarat
        /// Clienttan gönderilen tarih bilgisi kullanılmayacak.
        /// </summary>
        /// <param name="pinNote"></param>
        public IPinNote CreatePinNote(IPinNote pinNote)
        {
            pinNote.AddedDate = DateTime.Now;
            pinNote.ModifiedDate = DateTime.Now;
            return m_PinNoteRepository.Add(pinNote as PinNote);
        }

        /// <summary>
        /// PinNote Update et
        /// Clienttan gönderilen tarih bilgisi kullanılmayacak.
        /// </summary>
        /// <param name="pinNote"></param>
        public IPinNote UpdatePinNote(IPinNote pinNote)
        {
            pinNote.ModifiedDate = DateTime.Now;
            return m_PinNoteRepository.Update(pinNote as PinNote);
        }

        /// <summary>
        /// PinNoteu sil
        /// </summary>
        /// <param name="pinNote"></param>
        public void DeletePinNote(IPinNote pinNote)
        {
            m_PinNoteRepository.Delete(pinNote as PinNote);
        }

        /// <summary>
        /// ID değeri verilen pinNoteları sil
        /// </summary>
        /// <param name="IDs"></param>
        public void DeletePinNotesByID(List<int> IDs)
        {
            m_PinNoteRepository.Delete(x => IDs.Contains(x.ID));
        }
    }
}
