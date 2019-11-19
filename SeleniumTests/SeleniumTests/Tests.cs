using System;
using System.Threading;
using NUnit.Framework;

namespace SeleniumTests
{
    [TestFixture]
    public class Tests : BrowserBaseFunction
    {
        private const string ErrorTextForEmptyString =
            "Arrival city/airport is required.";

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
            const string departureCityText = "MSQ";

            GetWebElementById("reservationFlightSearchForm.originAirport").SendKeys(departureCityText);
            GetWebElementById("aa-leavingOn").SendKeys("11/04/2019");
            GetWebElementById("aa-returningFrom").SendKeys("11/05/2019");

            GetWebElementById("flightSearchForm.button.reSubmit").Click();

            //string error = GetWebElementById("segments0.destination.errors").Text;
            //Assert.AreEqual(ErrorTextForEmptyString, error);

            if (GetUrl().Equals("https://www.aa.com/booking/find-flights"))
            {
                string error = GetWebElementById("segments0.destination.errors").Text;
                Assert.AreEqual(ErrorTextForEmptyString, error);
            }
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
            const string firstNameText = "Jane";
            const string lastNameText = "Fox";
            const string reservationNumberText = "123456";

            GetWebElementById("jq-myTripsCheckIn").Click();

            GetWebElementById("retr-firstName").SendKeys(firstNameText);
   
            GetWebElementById("retr-lastName").SendKeys(lastNameText);

            GetWebElementById("retr-recordLocator").SendKeys(reservationNumberText);

            GetWebElementById("prs-submit").Click();

            string error = GetWebElementByXPath("//li[@class = 'errorMessage']").Text;
         
            Assert.AreEqual(ErrorTextForTheWrongReservationNumber, error);
        }
    }
}
