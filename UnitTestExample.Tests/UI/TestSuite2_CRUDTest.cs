using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace UnitTestExample.Tests.UI
{
    [TestClass]
    public class TestSuite2_CRUDTest : WebDriverInit
    {
        //Ordering your test cases
        //A test named Test14 will run before Test2 even though the number 2 is less than 14. This is because, test name ordering uses the text name of the test.
        [TestMethod]
        [DataRow("Jack Sparrow", "115 Main St", "3", "test@gmail.com")]
        public void Test1_CreateNewContact_Success(string name, string address, string companyId, string email)
        {
            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");
            
            Thread.Sleep(1000);

            d.FindElement(By.XPath("/html/body/div/main/section/div/div[1]/h3/a")).Click();

            Thread.Sleep(1000);

            var title = d.FindElement(By.XPath("/html/body/div/main/section/div/div/div/div/div/h3")).Text;

            Assert.AreEqual("Add New Contact\r\nBack", title);

            d.FindElement(By.Id("Name")).SendKeys(name); ;
            d.FindElement(By.Id("Address")).SendKeys(address); ;
            d.FindElement(By.Id("LastDateContacted")).SendKeys(DateTime.Now.ToString("MM/dd/yyyy")); ;
            var company = d.FindElement(By.Id("CompanyId"));
            var selectElement = new SelectElement(company);
            selectElement.SelectByValue(companyId);
            d.FindElement(By.Id("Email")).SendKeys(email);

            Thread.Sleep(2000);

            d.FindElement(By.XPath(@"//*[@id=""contact""]/div/div/div[2]/fieldset/div/div[4]/button")).Click();

            Thread.Sleep(500);

            d.FindElement(By.XPath(@"//*[@id=""Confirmation""]/div/div/div[3]/button[2]")).Click();

            Thread.Sleep(1000);

            var homeTitle = d.FindElement(By.XPath("/html/body/div/main/div[1]/h1")).Text;

            Assert.AreEqual("Welcome", homeTitle);

            d.Quit();
        }

        // it will update the first row of the grid
        [TestMethod]
        [DataRow("Robin Sparrow", "775 Main St", "2", "update@gmail.com")]
        public void Test2_UpdateContact_Success(string name, string address, string companyId, string email)
        {

            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");

            Thread.Sleep(1000);

            //id of the record should be dynamic
            d.FindElement(By.XPath(@"//*[@id=""contact""]/tbody/tr[1]/td[7]/div/a[1]")).Click();

            Thread.Sleep(2000);

            var title = d.FindElement(By.XPath("/html/body/div/main/section/div/div/div/div/div/h3")).Text;

            Assert.AreEqual("Update Contact\r\nBack", title);

            var nameEle = d.FindElement(By.Id("Name"));
            nameEle.Clear();
            nameEle.SendKeys(name);

            var addressEle = d.FindElement(By.Id("Address"));
            addressEle.Clear();
            addressEle.SendKeys(address);

            var dateEle = d.FindElement(By.Id("LastDateContacted"));
            dateEle.Clear();
            dateEle.SendKeys(DateTime.Now.AddDays(-5).ToString("MM/dd/yyyy"));

            var company = d.FindElement(By.Id("CompanyId"));
            var selectElement = new SelectElement(company);
            selectElement.SelectByValue(companyId);

            var emailEle = d.FindElement(By.Id("Email"));
            emailEle.Clear();
            emailEle.SendKeys(email);

            Thread.Sleep(2000);

            d.FindElement(By.XPath(@"//*[@id=""contact""]/div/div/div[2]/fieldset/div/div[4]/button")).Click();

            Thread.Sleep(500);

            /////*[@id="Confirmation"]/div/div/div[3]/button[2]
            d.FindElement(By.XPath(@"//*[@id=""Confirmation""]/div/div/div[3]/button[2]")).Click();

            Thread.Sleep(1000);

            var homeTitle = d.FindElement(By.XPath("/html/body/div/main/div[1]/h1")).Text;

            Assert.AreEqual("Welcome", homeTitle);

            d.Quit();
        }

        // it will update the first row of the grid
        [TestMethod]
        public void Test3_RemoveContact_Success()
        {

            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");

            Thread.Sleep(1000);

            //id of the record should be dynamic
            d.FindElement(By.XPath(@"//*[@id=""contact""]/tbody/tr[1]/td[7]/div/a[2]")).Click();

            Thread.Sleep(2000);

            /////*[@id="Confirmation"]/div/div/div[3]/button[2]
            d.FindElement(By.XPath(@"//*[@id=""Confirmation""]/div/div/div[3]/button[2]")).Click();

            //wait till toast is loaded
            Thread.Sleep(1000);

            var deleteSuccess = d.FindElement(By.CssSelector(@"div[class='toast-message']")).Text;

            Assert.AreEqual("Deleted Successfully!", deleteSuccess);

            d.Quit();
        }
    }
}

