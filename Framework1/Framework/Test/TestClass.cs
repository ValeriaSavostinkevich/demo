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

namespace Framework.Test
{
    public class TestClass : CommonConditions
    {
        const string ErrorTextForSearchWithoutEnteringInformation =
            "Please select your destination";

        const string ErrorTextForSearchByEnteringTheWrongBookingReference =
            "Please enter a valid reservation number.";

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
                .InputLastNameAndBookingReference(userCreator.WithAllProperties())
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
        public void EqualPreliminaryAndCurrentPrice()
        {
            MakeScreenshotWhenFail(() =>
            {
                Route route = new RouteCreator().WithAllProperties();
                HomePage homePage = new HomePage(Driver);
                homePage.CookieAcceptClick();
                homePage.InputOriginSurrogate(route.OriginSurrogate);
                homePage.InputDestinationSurrogate(route.DestinationSurrogate);
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
            });
        }
    }
}
