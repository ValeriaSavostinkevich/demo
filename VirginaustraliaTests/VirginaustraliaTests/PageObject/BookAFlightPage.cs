using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    public class BookAFlightPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        //[FindsBy(How = How.XPath, Using = "//label[contains(., 'One Way')]")]
        //private IWebElement OneWayRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        private IWebElement FlightsOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        private IWebElement FlightsDestinationSurrogate;

        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Find Flights')]")]
        private IWebElement FindFlightsButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='flights-oneway']")]
        private IWebElement OneWayRadioButton;

        public BookAFlightPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        
        public BookAFlightPage InputFlightsOriginAndDestinationSurrogate(string originSurrogate, string destinationSurrogate)
        {
            FlightsOriginSurrogate.SendKeys(originSurrogate);
            FlightsDestinationSurrogate.SendKeys(destinationSurrogate);
            return this;
        }

        public BookAFlightPage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            return this;
        }

        public SelectFlightsPage FindFlightsButtonClick()
        {
            FindFlightsButton.Click();
            return new SelectFlightsPage(Driver);
        }
    }
}
