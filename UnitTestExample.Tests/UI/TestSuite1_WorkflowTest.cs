using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestExample.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Threading;

[assembly: Parallelize(Workers = 1, Scope = ExecutionScope.MethodLevel)]

namespace UnitTestExample.Tests.UI
{
    [TestClass]
    public class TestSuite1_WorkflowTest : WebDriverInit
    {

        [TestMethod]
        [DataRow(BrowserType.Chrome, "Windows 11", "103.0.5060.134", "Chrome Test")]
        [DataRow(BrowserType.Firefox, "Windows 11", "103.0", "Firefox Test")]
        public void Test1_OpenTheApplicationInBrowser_Success(BrowserType browserType, string platform, string version, string name)
        {

            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");

            d.Quit();
            //var f = new FirefoxDriver();
            //f.Manage().Window.Maximize();
            //f.Navigate().GoToUrl("https://localhost:7280/");

            //f.Quit();

            //using (var driver = GetWebDriver(browserType, platform, version, name))
            //{
            //    driver.Navigate().GoToUrl("https://localhost:7280/");
            //    string itemText = driver.FindElement(By.XPath("/html/body/div/main/div[1]/h1")).Text;
            //    Assert.AreEqual("Welcome", itemText);

            //    driver.Quit();
            //}
        }
        [TestMethod]
        public void Test1_CreateNewContactClick_Success()
        {

            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");
            d.FindElement(By.XPath("/html/body/div/main/section/div/div[1]/h3/a")).Click();

            Thread.Sleep(2000);

            var title = d.FindElement(By.XPath("/html/body/div/main/section/div/div/div/div/div/h3")).Text;

            Assert.AreEqual("Add New Contact\r\nBack", title);

            d.Quit();
        }

        [TestMethod]
        public void Test1_BackToHomeClick_Success()
        {

            var d = new ChromeDriver();
            d.Manage().Window.Maximize();
            d.Navigate().GoToUrl("https://localhost:7280/");
            d.FindElement(By.XPath("/html/body/div/main/section/div/div[1]/h3/a")).Click();

            Thread.Sleep(1000);

            var title = d.FindElement(By.XPath("/html/body/div/main/section/div/div/div/div/div/h3")).Text;

            Assert.AreEqual("Add New Contact\r\nBack", title);

            d.FindElement(By.XPath("/html/body/div/main/section/div/div/div/div/div/h3/a")).Click();

            Thread.Sleep(1000);

            var homeTitle = d.FindElement(By.XPath("/html/body/div/main/div[1]/h1")).Text;

            Assert.AreEqual("Welcome", homeTitle);

            d.Quit();
        }
    }
}
