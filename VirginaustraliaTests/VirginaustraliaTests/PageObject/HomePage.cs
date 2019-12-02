using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    public class HomePage
    {
        private IWebDriver Driver;

        private readonly string Url = "https://www.virginaustralia.com/eu/en/";

        [FindsBy(How = How.XPath, Using = "//button[@id = 'cookieAcceptButton']")]
        private IWebElement CookieAcceptButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-submit']")]
        private IWebElement FindFlightsButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='page-dialog']/div/ul/li")]
        private IWebElement PageDialog;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'My bookings')]")]
        private IWebElement MyBookings;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-last-name']")]
        private IWebElement FlightsManageLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-manage-pnr']")]
        private IWebElement FlightsManageBookingReference;

        [FindsBy(How = How.XPath, Using = "//input[@value = 'RETRIEVE']")]
        private IWebElement RetrieveButtonOnMyBookings;

        [FindsBy(How = How.XPath, Using = "//label[contains(., 'One Way')]")]
        private IWebElement OneWayRadioButton;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-return-date']")]
        private IWebElement FlightsReturnDate;

        [FindsBy(How = How.XPath, Using = "//span[@id = 'label_fake-adult-input']")]
        private IWebElement CustomFormSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='incInfants']/img")]
        private IWebElement IncrementInfants;

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Planning')]")]
        private IWebElement PlanningButton;


        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(Url);
        }

        public HomePage CookieAcceptClick()
        {
            CookieAcceptButton.Click();
            return this;
        }

        public PlanningPage GoToPlanningPage()
        {
            PlanningButton.Click();
            return new PlanningPage(Driver);
        }

        public HomePage GoToMyBooking()
        {
            MyBookings.Click();
            return this;
        }

        public HomePage FindFlightsButtonClick()
        {
            FindFlightsButton.Click();
            return this;
        }

        public string GetPageDialogText()
        {
            return PageDialog.Text;
        }

        public HomePage RetrieveButtonOnMyBookingsClick()
        {
            RetrieveButtonOnMyBookings.Click();
            return this;
        }

        public HomePage InputLastNameAndBookingReference(string lastName, string bookingReference)
        {
            FlightsManageLastName.SendKeys(lastName);
            FlightsManageBookingReference.SendKeys(bookingReference);
            return this;
        }

        public HomePage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            return this;
        }

        public bool FlightsReturnDateIsEnabled()
        {
            return FlightsReturnDate.Enabled;
        }

        public HomePage CustomFormSelectClick()
        {
            CustomFormSelect.Click();
            return this;
        }

        public HomePage IncInfantsClick()
        {
            IncrementInfants.Click();
            return this;
        }

        public string GetAttributeButtonInfants()
        {
            return IncrementInfants.GetAttribute("style");
        }
    }
}
