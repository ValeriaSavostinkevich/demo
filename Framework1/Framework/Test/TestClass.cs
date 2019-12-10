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
            Log.Info("CookieAcceptClick");
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
        public void CheckHelpPage()
        {
            HelpPage helpPage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToHelpPage();
            Assert.AreEqual(helpPage.GetUrlHelpPage(), HelpPageUrl);
        }

        [Test]
        public void CheckPlanningPage()
        {
            PlanningPage planningPage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToPlanningPage();
            Assert.AreEqual(planningPage.GetUrl(), PlanningPageUrl);
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

            string PageDialogText = home.GetAttributeErrorForm();
            Assert.AreEqual(PageDialogText, "display: block;");
        }

        [Test]
        public void LogInWithIncorrectInformation()
        {
            UserCreator userCreator = new UserCreator();
            bool enabledErrorForm = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToLogInPage()
                .InputVelocityNumberAndBookingReference(userCreator.LastNameVelocityNumberAndPasswordProperties())
                .LogInButtonClick()
                .ErrorFormIsEnabled();
            Assert.IsTrue(enabledErrorForm);
        }

        [Test]
        public void EqualPreliminaryAndCurrentPrice()
        {
            Route route = new RouteCreator().WithAllProperties();
            SelectFlightsPage selectFlightsPage = new HomePage(Driver)
                .CookieAcceptClick()
                .GoToPlanningPage()
                .GoToBookAFlightPage()
                .InputFlightsOriginAndDestinationSurrogate(route)
                .OneWayRadioButtonClick()
                .FindFlightsButtonClick()
                .SelectFlightClick()
                .SelectPriceClick()
                .ContinueButtonClick();
            Assert.AreEqual(selectFlightsPage.GetPreliminaryPrice(), selectFlightsPage.GetCurrentPrice());
        }
    }
}
