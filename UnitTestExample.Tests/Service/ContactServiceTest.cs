using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample.DataAccess.IRepository;
using UnitTestExample.Models;
using UnitTestExample.Models.ViewModels;
using UnitTestExample.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Tests.Service
{
    [TestClass]
    public class ContactServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public ContactServiceTest()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public async Task AddContact_Success()
        {
            _unitOfWorkMock.Setup(x => x.Contact.AddAsync(It.IsAny<Contact>())).Returns(Task.CompletedTask);
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<Contact>(It.IsAny<ContactVM>())).Returns(new Contact() { Id = 1 });
            var contactService = new ContactService(_unitOfWorkMock.Object, _mapperMock.Object);

            var response = await contactService.AddContact(new ContactVM { Id = 1, LastDateContacted = "01/01/2022" });

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Message, "Contact has been added successfully!");
        }

        [TestMethod]
        public async Task UpdateContact_Success()
        {
            var date = DateTime.Now;
            _unitOfWorkMock.Setup(x => x.Contact.GetAsync(It.IsAny<int>())).ReturnsAsync(new Contact() { Id = 2, LastDateContacted = date });
            _unitOfWorkMock.Setup(x => x.Contact.UpdateAsync(It.IsAny<Contact>())).ReturnsAsync(new Contact() { Id = 2, LastDateContacted = date });
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<Contact>(It.IsAny<ContactVM>())).Returns(new Contact() { Id = 2, LastDateContacted = date });
            var contactService = new ContactService(_unitOfWorkMock.Object, _mapperMock.Object);

            var response = await contactService.UpdateContact(new ContactVM { Id = 2, LastDateContacted = date.ToString("MM/dd/yyyy") });

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Message, "Contact has been updated successfully!");
        }

        [TestMethod]
        public async Task UpdateContact_Fail()
        {
            _unitOfWorkMock.Setup(x => x.Contact.UpdateAsync(new Contact() { Id = 2 })).ReturnsAsync(new Contact() { Id = 2 });
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);
            _mapperMock.Setup(x => x.Map<Contact>(It.IsAny<ContactVM>())).Returns(new Contact() { Id = 2 });
            var contactService = new ContactService(_unitOfWorkMock.Object, _mapperMock.Object);

            var response = await contactService.UpdateContact(new ContactVM { Id = 2, LastDateContacted = "01/01/2022" });

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Message, "Invalid request!");
        }


        [TestMethod]
        public async Task GetContact_Success()
        {
            _unitOfWorkMock.Setup(x => x.Contact.GetAsync(It.IsAny<int>())).ReturnsAsync(new Contact() { Id = 1 });

            _mapperMock.Setup(x => x.Map<ContactVM>(It.IsAny<Contact>())).Returns(new ContactVM() { Id = 1 });
            var contactService = new ContactService(_unitOfWorkMock.Object, _mapperMock.Object);

            var response = await contactService.GetContact(1);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(ContactVM));
        }

        [TestMethod]
        public async Task DeleteContact_Success()
        {
            _unitOfWorkMock.Setup(x => x.Contact.GetAsync(It.IsAny<int>())).ReturnsAsync(new Contact() { Id = 1 });

            _unitOfWorkMock.Setup(x => x.Contact.RemoveAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).Returns(Task.CompletedTask);

            var contactService = new ContactService(_unitOfWorkMock.Object, _mapperMock.Object);

            var response = await contactService.DeleteContact(1);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Message, "Deleted Successfully!");
        }
    }
}
