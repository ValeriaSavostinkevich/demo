using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using VirginaustraliaTests.PageObject;

namespace VirginaustraliaTests
{
    public class TestClass
    {
        private IWebDriver driver;

        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference = 
            "Please enter a valid reservation number.";

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [Test]
        public void SearchWithoutEnteringInformationTest()
        {
            HomePage homePage = new HomePage(driver);
            SelectFlightsPage selectFlightsPage =  homePage
                .CookieAcceptClick()
                .FindFlightsButtonClick();
            Assert.AreEqual(homePage.GetPageDialogText(), ErrorTextForSearchWithoutEnteringInformation);
        }

        [Test]
        public void SearchByEnteringTheWrongBookingReferenceTest()
        {
            string PageDialogText = new HomePage(driver)
                .CookieAcceptClick()
                .GoToMyBooking()
                .InputLastNameAndBookingReference("Savostinkevich", "123456")
                .RetrieveButtonOnMyBookingsClick()
                .GetPageDialogText();
            Assert.AreEqual(PageDialogText, 
                            ErrorTextForSearchByEnteringTheWrongBookingReference);
        }

        [Test]
        public void FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            bool FlightsReturnDateIsEnabled = new HomePage(driver)
                .CookieAcceptClick()
                .OneWayRadioButtonClick()
                .FlightsReturnDateIsEnabled();
            Assert.IsFalse(FlightsReturnDateIsEnabled);
        }

        [Test]
        public void OneInfantPerOneAdultTest()
        {
            string AttributeButtonInfants = new HomePage(driver)
                .CookieAcceptClick()
                .CustomFormSelectClick()
                .IncrementInfantsClick()
                .GetAttributeButtonInfants();
            Assert.AreEqual(AttributeButtonInfants, "cursor: default;");
        }

        [Test]
        public void Test()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CookieAcceptClick();
            homePage.InputOriginSurrogate("Brisbane (BNE)");
            homePage.InputDestinationSurrogate("Adelaide (ADL)");
            homePage.OneWayRadioButtonClick();
            SelectFlightsPage selectFlightsPage = homePage.FindFlightsButtonClick();
           // PlanningPage planningPage = homePage.GoToPlanningPage();
           // BookAFlightPage bookAFlightPage = planningPage.GoToBookAFlightPage();
           // bookAFlightPage.InputFlightsOriginAndDestinationSurrogate();
           // bookAFlightPage.OneWayRadioButtonClick();
           //bookAFlightPage.FindFlightsButtonClick();
            selectFlightsPage.SelectFlightClick();
            selectFlightsPage.SelectPriceClick();
            selectFlightsPage.ContinueButtonClick();
            Assert.AreEqual(selectFlightsPage.GetPreliminaryPrice(), selectFlightsPage.GetCurrentPrice());
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
