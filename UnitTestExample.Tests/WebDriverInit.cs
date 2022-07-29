using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestExample.Tests
{
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Edge,
        Safari
    }
    public class WebDriverInit
    {
        public IWebDriver GetWebDriver(BrowserType browserType, string platform, string version, string name)
        {
            dynamic capability = GetBrowserOptions(browserType);

            capability.AddArguments("--start-maximized");
            capability.AddAdditionalOption("platform", platform);
            capability.AddAdditionalOption("version", version);
            capability.AddAdditionalOption("name", name);
            capability.AddAdditionalOption("build", "Parallel Browser Testing");

            IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
            //driver.Navigate().GoToUrl("http://www.google.com");

            //driver.Manage().Window.Maximize();
            driver.Url = "https://localhost:7280/";

            return driver;
        }
        //public IWebDriver GetWebDriver(BrowserType browserType, string platform, string version, string name)
        //{
        //    dynamic driver = GetWebDriverInstance(browserType);

        //    //capability.AddArguments("--start-maximized");
        //    //capability.AddAdditionalOption("platform", platform);
        //    //capability.AddAdditionalOption("version", version);
        //    //capability.AddAdditionalOption("name", name);
        //    //capability.AddAdditionalOption("build", "Parallel Browser Testing");

        //    //IWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4444/"), capability);
        //    //driver.Navigate().GoToUrl("http://www.google.com");

        //    driver.Manage().Window.Maximize();
        //    driver.Url = "https://localhost:7280/";

        //    return driver;
        //}
        private dynamic GetBrowserOptions(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeOptions();
                    break;
                case BrowserType.Firefox:
                    return new FirefoxOptions();
                    break;
                case BrowserType.Edge:
                    return new EdgeOptions();
                    break;
                case BrowserType.Safari:
                    return new SafariOptions();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
        private dynamic GetWebDriverInstance(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    return new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    return new EdgeDriver();
                    break;
                case BrowserType.Safari:
                    return new SafariDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
            }
        }
    }
}
