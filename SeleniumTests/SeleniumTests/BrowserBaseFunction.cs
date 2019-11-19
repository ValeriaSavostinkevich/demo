using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    public abstract class BrowserBaseFunction
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrouserAndGoToTheTestSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("https://www.aa.com/homePage.do?locale=en_US");
        }

        [TearDown]
        public void CloseBrouser()
        {
            webDriver.Quit();
            webDriver.Dispose();
        }

        protected string GetUrl()
        {
            return webDriver.Url;
        }

        protected IWebElement GetWebElementById(string Id)
        {
            return webDriver.FindElement(By.Id(Id));
        }

        protected IWebElement GetWebElementByXPath(string xPath)
        {
            return webDriver.FindElement(By.XPath(xPath));
        }
    }
}
