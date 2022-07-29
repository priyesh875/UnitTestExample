using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample.DataAccess.Data;
using UnitTestExample.DataAccess.Repository;
using UnitTestExample.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Tests.Repository
{
    [TestClass]
    public class ContactRepositoryTest
    {
        private readonly Mock<ApplicationDbContext> _dbMock;
        public ContactRepositoryTest()
        {
            _dbMock = new Mock<ApplicationDbContext>();
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsNull_WhenContactIsNull()
        {
            // Arrange
            var repository = new ContactRepository(_dbMock.Object);

            // Act
            var response = await repository.UpdateAsync(null);

            // Assert
            Assert.IsNull(response);

        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsNull_WhenContactDoesNotExist()
        {
            // Arrange
            _dbMock.Setup(x => x.Set<Contact>().FindAsync(It.IsAny<int>())).Returns(null);

            var repository = new ContactRepository(_dbMock.Object);

            // Act
            var response = await repository.UpdateAsync(new Contact() { Id = 1 });

            // Assert
            Assert.IsNull(response);

        }
    }
}
