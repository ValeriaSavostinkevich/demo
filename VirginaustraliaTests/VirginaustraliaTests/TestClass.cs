using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using VirginaustraliaTests.PageObject;

namespace VirginaustraliaTests
{
    class TestClass
    {
        private IWebDriver driver;

        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference = 
            "Please enter a valid reservation number.";

        [SetUp]
        public void OpenBrouser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
        }

        [Test]
        public void SearchWithoutEnteringInformationTest()
        {
            HomePage homePage = new HomePage(driver);
            Assert.AreEqual(homePage.SearchWithoutEnteringInformation(), ErrorTextForSearchWithoutEnteringInformation);
        }

        [Test]
        public void SearchByEnteringTheWrongBookingReferenceTest()
        {
            HomePage homePage = new HomePage(driver);
            Assert.AreEqual(homePage.SearchByEnteringTheWrongBookingReference("Savostinkevich", "123456"), ErrorTextForSearchByEnteringTheWrongBookingReference);
        }

        [Test]
        public void FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsFalse(homePage.FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay());
        }

        [Test]
        public void OneInfantPerOneAdultTest()
        {
            HomePage homePage = new HomePage(driver);
            Assert.AreEqual(homePage.OneInfantPerOneAdult(), "cursor: default;");
        }

        [Test]
        public void Test()
        {
            HomePage homePage = new HomePage(driver);
            BookAFlightPage bookAFlightPage = homePage.goToBookAFlightPage();
            SelectFlightsPage selectFlightsPage = bookAFlightPage.FindTickets("Brisbane (BNE)", "Adelaide (ADL)");
            Assert.AreEqual(selectFlightsPage.GetPreliminaryPrice(), selectFlightsPage.GetCurrentPrice());
        }

        [TearDown]
        public void CloseBrouser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
