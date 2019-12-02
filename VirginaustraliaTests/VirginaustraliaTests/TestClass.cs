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
            homePage.CookieAcceptClick();
            homePage.FindFlightsButtonClick();
            Assert.AreEqual(homePage.GetPageDialogText(), ErrorTextForSearchWithoutEnteringInformation);
        }

        [Test]
        public void SearchByEnteringTheWrongBookingReferenceTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CookieAcceptClick();
            homePage.GoToMyBooking();
            homePage.InputLastNameAndBookingReference("Savostinkevich", "123456");
            homePage.RetrieveButtonOnMyBookingsClick();
            Assert.AreEqual(homePage.GetPageDialogText(), 
                            ErrorTextForSearchByEnteringTheWrongBookingReference);
        }

        [Test]
        public void FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CookieAcceptClick();
            homePage.OneWayRadioButtonClick();
            Assert.IsFalse(homePage.FlightsReturnDateIsEnabled());
        }

        [Test]
        public void OneInfantPerOneAdultTest()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CookieAcceptClick();
            homePage.CustomFormSelectClick();
            homePage.IncInfantsClick();
            Assert.AreEqual(homePage.GetAttributeButtonInfants(), "cursor: default;");
        }

        [Test]
        public void Test()
        {
            HomePage homePage = new HomePage(driver);
            homePage.CookieAcceptClick();
            PlanningPage planningPage = homePage.GoToPlanningPage();
            BookAFlightPage bookAFlightPage = planningPage.GoToBookAFlightPage();
            bookAFlightPage.InputFlightsOriginAndDestinationSurrogate("Brisbane (BNE)", "Adelaide (ADL)");
            bookAFlightPage.OneWayRadioButtonClick();
            SelectFlightsPage selectFlightsPage = bookAFlightPage.FindFlightsButtonClick();
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
