using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;

namespace Framework.PageObject
{
    public class BookAFlightPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        private IWebElement FlightsOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        private IWebElement FlightsDestinationSurrogate;

        [FindsBy(How = How.XPath, Using = "//button[contains(., 'Find Flights')]")]
        private IWebElement FindFlightsButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'oneway-wrapper button-wrapper ']/input[@id='flights-oneway']")]
        private IWebElement OneWayRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-departure-date']")]
        private IWebElement FlightDepartureDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='calendar_container hasDatepicker']/div[@class = 'ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-datepicker-multi ui-datepicker-multi-2']/div[@class = 'ui-datepicker-group ui-datepicker-group-first']/table/tbody/tr[4]/td[@class = ' ui-datepicker-week-end ']/a[1]")]
        private IWebElement FlightDepartureDateInput;

        public BookAFlightPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        
        public BookAFlightPage InputDestinationSurrogate(Route route)
        {
            FlightsOriginSurrogate.Clear();
            FlightsOriginSurrogate.SendKeys(route.OriginSurrogate);
            FlightsDestinationSurrogate.SendKeys(route.DestinationSurrogate + Keys.Alt);
            
            return this;
        }

        public BookAFlightPage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            return this;
        }

        public BookAFlightPage FlightDepartureDateClick()
        {
            FlightDepartureDate.Click();
            return this;
        }

        public BookAFlightPage InputFlightDepartureDate()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='calendar_container hasDatepicker']/div[@class = 'ui-datepicker-inline ui-datepicker ui-widget ui-widget-content ui-helper-clearfix ui-corner-all ui-datepicker-multi ui-datepicker-multi-2']/div[@class = 'ui-datepicker-group ui-datepicker-group-first']/table/tbody/tr[4]/td[@class = ' ui-datepicker-week-end ']/a[1]")));
            FlightDepartureDateInput.Click();
            return this;
        }

        public SelectFlightsPage FindFlightsButtonClick()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(., 'Find Flights')]")));
            FindFlightsButton.Click();
            return new SelectFlightsPage(Driver);
        }
    }
}
