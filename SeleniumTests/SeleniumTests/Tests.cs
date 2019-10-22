using System;
using System.Threading;
using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests : BrouserBaseFunction
    {
        private const string ErrorTextForEmptyString =
            "Укажите город возвращения и повторите попытку.";

        private const string ErrorTextForTheWrongReservationNumber =
            "Введите действительный шестизначный номер бронирования.";

        //Пустое поле "В" при поиске рейса
        //Шаги:
        //-Зайти на сайт https://www.americanairlines.com.ru/intl/ru/
        //-Указать в поле "из" "MSQ"
        //-Оставить поле "в" пустым
        //-нажимаем кнопку "Поиск"
        //Ожидаемый результат: Появление сообщения "Укажите город отправления и повторите попытку".
        [Test]
        public void SearchWithoutEnteringTheCityOfArrival()
        {
            #region TestData

            const string departureCityText = "MSQ";

            #endregion

            var departureCity = GetWebElementById("reservationFlightSearchForm.originAirport");
            departureCity.SendKeys(departureCityText);
            var searchButton = GetWebElementById("bookingModule-submit");
            searchButton.Click();
            var errorMessage = GetWebElementByXPath("//li[@class = 'errorMessage']");
            string error = errorMessage.Text;
            Assert.AreEqual(ErrorTextForEmptyString, error);
        }

        //Ввод несуществующего номера резервации при просмотре вкладки "Мои перелёты"
        //Шаги:
        //-Зайти на сайт https://www.americanairlines.com.ru/intl/ru/
        //-Перейти на вкладку "Мои перелёты"
        //-Указать в поле "Имя пассажира"  Jane
        //-Указать в поле "Фамилия пассажира"  Fox
        //-Указать в поле "Номер рейса" 123456
        //-нажимаем кнопку "Найти бронирование"
        //Ожидаемый результат: Появление сообщения "Введите действительный шестизначный номер бронирования.".
        [Test]
        public void SearchWithWrongReservationNumber()
        {

            #region TestData

            const string firstNameText = "Jane";
            const string lastNameText = "Fox";
            const string reservationNumberText = "123456";

            #endregion

            var myTripsCheckIn = GetWebElementById("jq-myTripsCheckIn");
            myTripsCheckIn.Click();

            var firstName = GetWebElementById("retr-firstName");
            firstName.SendKeys(firstNameText);

            var lastName = GetWebElementById("retr-lastName");
            lastName.SendKeys(lastNameText);

            var reservationNumber = GetWebElementById("retr-recordLocator");
            reservationNumber.SendKeys(reservationNumberText);

            var searchButton = GetWebElementById("prs-submit");
            searchButton.Click();

            var errorMessage = GetWebElementByXPath("//li[@class = 'errorMessage']");
            string error = errorMessage.Text;
            Assert.AreEqual(ErrorTextForTheWrongReservationNumber, error);
        }
    }
}
