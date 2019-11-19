using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    class BookAFlightPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
       
        public BookAFlightPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label[contains(., 'One Way')]")]
        IWebElement OneWayRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        IWebElement FlightsOriginSurrogate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        IWebElement FlightsDestinationSurrogate { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Find Flights')]")]
        IWebElement FindFlightsButton { get; set; }

        public SelectFlightsPage FindTickets(string originSurrogate, string destinationSurrogate)
        {
            FlightsOriginSurrogate.SendKeys(originSurrogate);
            FlightsDestinationSurrogate.SendKeys(destinationSurrogate);
            FindFlightsButton.Click();
            return new SelectFlightsPage(driver);
        }
    }
}
