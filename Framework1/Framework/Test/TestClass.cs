using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using Framework.Test;
using Framework.Service;
using Framework.Models;
using log4net;

namespace Framework.Test
{
    public class TestClass : CommonConditions
    {
        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference =
            "Please enter a valid reservation number.";

        const string ErrorTextForCheckFlight =
            "Invalid flight number. Ensure it contains numbers only. For example, 123.";

        const string ErrorTextForCheckIn =
            "Please select your departure city";

        const string HelpPageUrl = "https://www.virginaustralia.com/eu/en/help/";

        const string PlanningPageUrl = "https://www.virginaustralia.com/eu/en/plan/";

        static private ILog Log = LogManager.GetLogger(typeof(TestClass));

        [Test]
        public void SearchWithoutEnteringInformationTest()
        {
            HomePage homePage = new HomePage(Driver);
            SelectFlightsPage selectFlightsPage =  homePage
                .CookieAcceptClick()
                .FindFlightsButtonClick();
            Assert.AreEqual(homePage.GetPageDialogText(), ErrorTextForSearchWithoutEnteringInformation);
        }

        [Test]
        public void SearchByEnteringTheWrongBookingReferenceTest()
        {
            UserCreator userCreator = new UserCreator();
            string PageDialogText = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToMyBooking()
                .InputLastNameAndBookingReference(userCreator.LastNameAndBookingReferenceProperties())
                .RetrieveButtonOnMyBookingsClick()
                .GetPageDialogText();
            Assert.AreEqual(PageDialogText, 
                            ErrorTextForSearchByEnteringTheWrongBookingReference);
        }

        [Test]
        public void FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            HomePage homePage = new HomePage(Driver)
                .CookieAcceptClick()
                .OneWayRadioButtonClick();
            Assert.IsFalse(homePage.FlightsReturnDateIsEnabled());
        }

        [Test]
        public void OneInfantPerOneAdultTest()
        {
            string AttributeButtonInfants = new HomePage(Driver)
                .CookieAcceptClick()
                .CustomFormSelectClick()
                .IncrementInfantsClick()
                .GetAttributeButtonInfants();
            Assert.AreEqual(AttributeButtonInfants, "cursor: default;");
        }

        [Test]
        public void CheckFlightStatusWithoutInputInformation()
        {
            string PageDialogText = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToFlightStatus()
                .CheckFlightsButtonClick()
                .GetPageDialogText();
            Assert.AreEqual(PageDialogText, ErrorTextForCheckFlight);
        }

        [Test]
        public void SearchByEnteringTheWrongInformationInCheckIn()
        {
            UserCreator userCreator = new UserCreator();
            RouteCreator route = new RouteCreator();
            HomePage home = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToCheckIn()
                .InputLastNameBookingReferenceAndOriginSurrogateCheckIn(userCreator.LastNameAndBookingReferenceProperties(), route.WithAllProperties())
                .CheckInButtonClick();

            Assert.IsTrue(home.ErrorFormIsDisplayed());
        }

        [Test]
        public void SearchWithoutEnteringInformationOnSelectFlightPageTest()
        {
            SelectFlightsPage selectFlightsPage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToPlanningPage()
                .GoToBookAFlightPage()
                .FindFlightsButtonClick();

            Assert.IsTrue(selectFlightsPage.ErrorFormIsDisplayed());
        }

        [Test]
        public void SearchHolidaysWithoutEnteringInformation()
        {
            HomePage homePage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToHolidays()
                .FindHolidayClick();

            Assert.IsTrue(homePage.ErrorFormIsDisplayed());
        }

        [Test]
        public void SearchHolidayCarsWithoutEnteringInformation()
        {
            HomePage homePage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToCars()
                .FindCarsClick();

            Assert.IsTrue(homePage.ErrorFormIsDisplayed());
        }

        [Test]
        public void EqualPreliminaryAndCurrentPrice()
        {
            Route route = new RouteCreator().WithAllProperties();
            SelectFlightsPage selectFlightsPage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToPlanningPage()
                .GoToBookAFlightPage()
                .InputDestinationSurrogate(route)
                
                .FlightDepartureDateClick()
                .InputFlightDepartureDate()
                .OneWayRadioButtonClick()
                .FindFlightsButtonClick();

            string currentPrice = selectFlightsPage.GetCurrentPrice();

            string preliminaryPrice = selectFlightsPage
                .SelectFlightClick()
                .SelectPriceClick()
                .ContinueButtonClick()
                .GetPreliminaryPrice();

            Assert.AreEqual(currentPrice, preliminaryPrice);
        }
    }
}
