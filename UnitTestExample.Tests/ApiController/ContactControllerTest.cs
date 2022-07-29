using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;
using UnitTestExample.Services.IServices;
using UnitTestExample.Models.ViewModels;
using UnitTestExample.Controllers.API;

namespace UnitTestExample.Tests.ApiController
{
    [TestClass]
    public class ContactControllerTest
    {
        private readonly Mock<IContactService> _contactServiceMock;

        public ContactControllerTest()
        {
            _contactServiceMock = new Mock<IContactService>();
        }

        [TestMethod]
        public async Task ContactController_Get_Success()
        {
            // Arrange
            _contactServiceMock.Setup(x => x.GetContact(It.IsAny<int>())).ReturnsAsync(new ContactVM() { Id = 1 });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Get() as OkObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);

        }

        [TestMethod]
        public async Task ContactController_PostReturnsError_WhenLastDateContactedIsMissing()
        {
            // Arrange           

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Post(new ContactVM() { Id = 1 }) as ObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual((resp.Value), "Please enter valid date.");
        }

        [TestMethod]
        public async Task ContactController_PostSuccess_WhenContactIdExists()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.UpdateContact(It.IsAny<ContactVM>())).ReturnsAsync(new ResultVM() { Message = "Success" });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Post(new ContactVM() { Id = 1, LastDateContacted = "01/01/2000" }) as OkObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(((ResultVM)resp.Value).Message, "Success");

        }

        [TestMethod]
        public async Task ContactController_PostSuccess_WhenContactIdDoesNotExists()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.AddContact(It.IsAny<ContactVM>())).ReturnsAsync(new ResultVM() { Message = "Success" });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Post(new ContactVM() { LastDateContacted = "01/01/2000" }) as OkObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(((ResultVM)resp.Value).Message, "Success");

        }

        [TestMethod]
        public async Task ContactController_PostThrowsException_WhenAddContactThrowsException()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.AddContact(It.IsAny<ContactVM>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Post(new ContactVM() { LastDateContacted = "01/01/2000" }) as ObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(resp.Value, "Test Exception");


        }

        [TestMethod]
        public async Task ContactController_PostThriowsException_WhenUpdateContactThrowsException()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.UpdateContact(It.IsAny<ContactVM>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Post(new ContactVM() { Id = 1, LastDateContacted = "01/01/2000" }) as ObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(resp.Value, "Test Exception");
        }

        [TestMethod]
        public async Task ContactController_PutReturnsError_WhenLastDateContactedIsMissing()
        {
            // Arrange           

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Put(new ContactVM() { Id = 1 }) as ObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(resp.Value, "Please enter valid date.");

        }

        [TestMethod]
        public async Task ContactController_PuttSuccess_WhenContactIdExists()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.UpdateContact(It.IsAny<ContactVM>())).ReturnsAsync(new ResultVM() { Message = "Success" });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Put(new ContactVM() { Id = 1, LastDateContacted = "01/01/2000" }) as OkObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(((ResultVM)resp.Value).Message, "Success");

        }

        [TestMethod]
        public async Task ContactController_PutSuccess_WhenContactIdDoesNotExists()
        {

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Put(new ContactVM() { LastDateContacted = "01/01/2000" }) as ObjectResult;

            // Assert
            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(resp.Value, "No data found!");

        }

        [TestMethod]
        public async Task ContactController_PutThrowsException_WhenUpdateContactThrowsException()
        {
            // Arrange           

            _contactServiceMock.Setup(x => x.UpdateContact(It.IsAny<ContactVM>())).ThrowsAsync(new Exception("Test Exception"));

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Put(new ContactVM() { Id = 1, LastDateContacted = "01/01/2000" }) as ObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 500);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(resp.Value, "Test Exception");


        }

        [TestMethod]
        public async Task ContactController_Delete_Success()
        {
            // Arrange
            _contactServiceMock.Setup(x => x.DeleteContact(It.IsAny<int>())).ReturnsAsync(new ResultVM() { Message = "Success" });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.Delete(1) as OkObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);
            Assert.IsNotNull(resp.Value);
            Assert.AreEqual(((ResultVM)resp.Value).Message, "Success");

        }

        [TestMethod]
        public async Task ContactController_GetCompanies_Success()
        {
            // Arrange
            _contactServiceMock.Setup(x => x.GetCompanies()).ReturnsAsync(new List<CompanyVM> { new CompanyVM() { Id = 1 } });

            // Act
            var controller = new ContactController(_contactServiceMock.Object);

            var resp = await controller.GetCompanies() as OkObjectResult;

            Assert.IsNotNull(resp);
            Assert.AreEqual(resp.StatusCode, 200);

        }
    }
}
