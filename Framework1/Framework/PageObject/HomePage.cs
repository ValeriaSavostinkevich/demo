using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using log4net;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver Driver;

        private readonly string Url = "https://www.virginaustralia.com/eu/en/";
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

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
        
        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-originSurrogate']")]
        private IWebElement FlightsOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-destinationSurrogate']")]
        private IWebElement FlightsDestinationSurrogate;

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

        [FindsBy(How = How.XPath, Using = "//a[contains(., 'Help')]")]
        private IWebElement HelpButton;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Flight status')]/a")]
        private IWebElement FlightStatus;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'submit-button-container']/input[@value = 'CHECK FLIGHT']")]
        private IWebElement CheckFlightButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='flights-status-flight-number-flight-number']")]
        private IWebElement FlightNumber;

        [FindsBy(How = How.XPath, Using = "//dt[contains(., 'Check-in')]")]
        private IWebElement CheckIn;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'submit-button-container']/input[@value = 'CHECK IN']")]
        private IWebElement CheckInButton;
        
        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-last-name']")]
        private IWebElement CheckInLastName;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-reservation-number']")]
        private IWebElement CheckInBookingReference;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'flights-checkin-originSurrogate']")]
        private IWebElement CheckInOriginSurrogate;

        [FindsBy(How = How.XPath, Using = "//li[@class = 'header-loginLnkVelocity']/a")] 
        private IWebElement LogIn;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable dialog-error']")]
        private IWebElement ErorrForm;

        [FindsBy(How = How.XPath, Using = "//a[@id='holidays-selector']")]
        private IWebElement Holidays;

        [FindsBy(How = How.XPath, Using = "//input[@id='holidays-submit']")]
        private IWebElement FindHolidaysButton;

        [FindsBy(How = How.XPath, Using = "//a[@id='cars-selector']")]
        private IWebElement Cars;

        [FindsBy(How = How.XPath, Using = "//input[@id='cars-submit']")]
        private IWebElement FindCarsButton;


        public HomePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(Url);
        }

        public HomePage CookieAcceptClick()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id = 'cookieAcceptButton']")));
            CookieAcceptButton.Click();
            Log.Info("CookieAcceptClick");
            return this;
        }

        public HomePage CheckInButtonClick()
        {
            CheckInButton.Click();
            Log.Info("CheckInButtonClick");
            return this;
        }

        public PlanningPage GoToPlanningPage()
        {
            PlanningButton.Click();
            Log.Info("PlanningPageButtonClick");
            return new PlanningPage(Driver);
        }

        public LogInPage GoToLogInPage()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[@class = 'header-loginLnkVelocity']/a")));
            LogIn.Click();
            return new LogInPage(Driver);
        }

        public HelpPage GoToHelpPage()
        {
            HelpButton.Click();
            Log.Info("Go To HelpPage");
            return new HelpPage(Driver);
        }

        public HomePage GoToFlightStatus()
        {
            FlightStatus.Click();
            return this;
        }

        public HomePage GoToCheckIn()
        {
            CheckIn.Click();
            return this;
        }

        public HomePage GoToMyBooking()
        {
            MyBookings.Click();
            return this;
        }

        public HomePage GoToHolidays()
        {
            Holidays.Click();
            return this;
        }

        public HomePage FindHolidayClick()
        {
            FindHolidaysButton.Click();
            return this;
        }

        public HomePage GoToCars()
        {
            Cars.Click();
            return this;
        }

        public HomePage FindCarsClick()
        {
            FindCarsButton.Click();
            return this;
        }

        public SelectFlightsPage FindFlightsButtonClick()
        {
            FindFlightsButton.Click();
            return new SelectFlightsPage(Driver);
        }

        public HomePage CheckFlightsButtonClick()
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class = 'submit-button-container']/input[@value = 'CHECK FLIGHT']")));
            CheckFlightButton.Click();
            return this;
        }

        public HomePage RetrieveButtonOnMyBookingsClick()
        {
            RetrieveButtonOnMyBookings.Click();
            return this;
        }

        public HomePage OneWayRadioButtonClick()
        {
            OneWayRadioButton.Click();
            return this;
        }

        public HomePage CustomFormSelectClick()
        {
            CustomFormSelect.Click();
            return this;
        }

        public HomePage IncrementInfantsClick()
        {
            IncrementInfants.Click();
            return this;
        }

        public HomePage InputLastNameBookingReferenceAndOriginSurrogateCheckIn(User user, Route route)
        {
            CheckInOriginSurrogate.SendKeys(route.OriginSurrogate);
            CheckInBookingReference.SendKeys(user.BookingReference);
            CheckInLastName.SendKeys(user.LastName);
            return this;
        }

        public HomePage InputLastNameAndBookingReference(User user)
        {
            FlightsManageLastName.SendKeys(user.LastName);
            FlightsManageBookingReference.SendKeys(user.BookingReference);
            return this;
        }

        public HomePage InputOriginSurrogate(string originSurrogate)
        {
            FlightsOriginSurrogate.Clear();
            FlightsOriginSurrogate.SendKeys(originSurrogate);
            return this;
        }

        public HomePage InputDestinationSurrogate(string destinationSurrogate)
        {
            FlightsDestinationSurrogate.SendKeys(destinationSurrogate + Keys.Enter);
            return this;
        }

        public bool FlightsReturnDateIsEnabled()
        {
            return FlightsReturnDate.Enabled;
        }

        public string GetAttributeButtonInfants()
        {
            return IncrementInfants.GetAttribute("style");
        }

        public string GetPageDialogText()
        {
            return PageDialog.Text;
        }

        public bool ErrorFormIsDisplayed()
        {
            return ErorrForm.Displayed; ;
        }
    }
}
