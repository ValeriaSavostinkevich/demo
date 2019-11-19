using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    class HomePage
    {
        private IWebDriver driver;

        private readonly string url = "https://www.virginaustralia.com/eu/en/";

        [FindsBy(How = How.XPath, Using = "//button[@id = 'cookieAcceptButton']")]
        IWebElement CookieAcceptButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-submit']")]
        IWebElement FindFlightsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='page-dialog']/div/ul/li")]
        IWebElement PageDialog { get; set; }

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'My bookings')]")]
        IWebElement MyBookings { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-last-name']")]
        IWebElement FlightsManageLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-pnr']")]
        IWebElement FlightsManageBookingReference { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value = 'RETRIEVE']")]
        IWebElement RetrieveButtonOnMyBookings { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(., 'One Way')]")]
        IWebElement OneWayRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-return-date']")]
        IWebElement FlightsReturnDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id = 'label_fake-adult-input']")]
        IWebElement CustomFormSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='incInfants']/img")]
        IWebElement IncInfants { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Book a flight')]")]
        IWebElement BookAFlightButton { get; set; }

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
        }

        public BookAFlightPage goToBookAFlightPage()
        {
            CookieAcceptButton.Click();
            BookAFlightButton.Click();
            return new BookAFlightPage(driver);
        }

        public string SearchWithoutEnteringInformation()
        {
            CookieAcceptButton.Click();
            FindFlightsButton.Click();
            return PageDialog.Text;
        }

        public string SearchByEnteringTheWrongBookingReference(string lastName, string bookingReference)
        {
            CookieAcceptButton.Click();
            MyBookings.Click();
            FlightsManageLastName.SendKeys(lastName);
            FlightsManageBookingReference.SendKeys(bookingReference);
            RetrieveButtonOnMyBookings.Click();
            return PageDialog.Text;
        }

        public bool FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            CookieAcceptButton.Click();
            OneWayRadioButton.Click();
            return FlightsReturnDate.Enabled;
        }

        public string OneInfantPerOneAdult()
        {
            CookieAcceptButton.Click();
            CustomFormSelect.Click();
            IncInfants.Click();
            return IncInfants.GetAttribute("style");
        }
    }
}
