using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumTests
{
    public abstract class BrouserBaseFunction
    {
        public IWebDriver webDriver;

        [SetUp]
        public void OpenBrouserAndGoToTheTestSite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(200);
            webDriver.Navigate().GoToUrl("https://www.americanairlines.com.ru/");
        }

        [TearDown]
        public void CloseBrouser()
        {
            webDriver.Quit();
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
