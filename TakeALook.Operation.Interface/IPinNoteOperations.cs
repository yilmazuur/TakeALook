using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Operation.Interface
{
    public interface IPinNoteOperations : IDisposable
    {
        IEnumerable<IPinNote> GetPinNotes();
        IEnumerable<IPinNote> GetPinNotes(string name); 
        IEnumerable<IPinNote> GetPinNotesByUser(string userIdentifier);
        IPinNote GetPinNote(int id);
        IPinNote CreatePinNote(IPinNote pinNote);
        IPinNote UpdatePinNote(IPinNote pinNote);
        void DeletePinNote(IPinNote pinNote);
        void DeletePinNotesByID(List<int> id);
    }
}
