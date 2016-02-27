using TakeALook.API.Core.Controllers;
using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation;
using TakeALook.Operation.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace TakeALook.UnitTest
{
    [TestFixture]
    public class PinNoteOperationTest
    {
        private Mock<IPinNoteOperations> m_FakePinNoteOperations;
        private IPinNoteOperations m_PinNoteOperations;
        //private PinNoteController pinNoteController;

        [SetUp]
        public void Setup() 
        {
            m_FakePinNoteOperations = new Mock<IPinNoteOperations>();
            m_PinNoteOperations = new PinNoteOperations();
            //Controller request
            //pinNoteController = new PinNoteController()
            //{
            //    Request = new HttpRequestMessage()
            //    {
            //        Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
            //    }
            //};
        }

        [Test]
        public void GetAllPinNotes() 
        {
            //gerçek pinNotelar çekildi. bambaşka yaratılsa da olurdu
            IEnumerable<IPinNote> fakePinNotes = m_PinNoteOperations.GetPinNotes();
            int count = fakePinNotes.Count();
            //Fake operationa request geldiğinde dbden memoryden sonuç dönülecek: fakePinNotes
            m_FakePinNoteOperations.Setup(x => x.GetPinNotes()).Returns(fakePinNotes);

            //controller üzerinden aksiyon
            var response = m_FakePinNoteOperations.Object.GetPinNotes();
            Assert.IsNotNull(response);
            Assert.AreEqual(count, response.Count());
        }

        [Test]
        [TestCase("test")]
        public void GetPinNoteByName(string name)
        {
            IEnumerable<IPinNote> fakePinNotes = m_PinNoteOperations.GetPinNotes(name);
            int count = fakePinNotes.Count();
            m_FakePinNoteOperations.Setup(x => x.GetPinNotes(name)).Returns(fakePinNotes);
            var response = m_FakePinNoteOperations.Object.GetPinNotes(name);
            Assert.IsNotNull(response);
            Assert.AreEqual(count, response.Count());
        }

        [Test]
        [TestCase("test")]
        public void GetPinNotesByUser(string username)
        {
            IEnumerable<IPinNote> fakePinNotes = m_PinNoteOperations.GetPinNotesByUser(username);
            int count = fakePinNotes.Count();
            m_FakePinNoteOperations.Setup(x => x.GetPinNotesByUser(username)).Returns(fakePinNotes);
            var response = m_FakePinNoteOperations.Object.GetPinNotesByUser(username);
            Assert.IsNotNull(response);
            Assert.AreEqual(count, response.Count());
        }

        [Test]
        [TestCase(2)]
        public void GetPinNote(int id)
        {
            IPinNote fakePinNote = m_PinNoteOperations.GetPinNote(id);
            m_FakePinNoteOperations.Setup(x => x.GetPinNote(id)).Returns(fakePinNote);
            var response = m_FakePinNoteOperations.Object.GetPinNote(id);
            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.ID);
        }

        [Test]
        [TestCase(2)]
        public void CreatePinNote(int id)
        {
            IPinNote fakePinNote = m_PinNoteOperations.GetPinNote(id);
            m_FakePinNoteOperations.Setup(x => x.CreatePinNote(fakePinNote)).Returns(fakePinNote);
            var response = m_FakePinNoteOperations.Object.CreatePinNote(fakePinNote);
            Assert.AreEqual(id, response.ID);
            Assert.AreEqual(fakePinNote.Name, response.Name);
        }
    }
}
