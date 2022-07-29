using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample.Helper;

namespace UnitTestExample.Tests.Helper
{
    [TestClass]
    public class SDTest
    {
        [TestMethod]
        public void ToDateTime_ReturnsConvertedDate_WhenCorrectFormatOfDateIsPassed()
        {
            var response = SD.ToDateTime("01/01/2000");
            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Value.Day);

        }

        [TestMethod]
        public void ToDateTime_ReturnsNull_WhenInCorrectFormatOfDateIsPassed()
        {
            var response = SD.ToDateTime("somestring");
            Assert.IsNull(response);

        }
    }
}
