using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class SelectFlightsPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'cart-total-price total-bottom']/em[@class = 'total-price-container']/span/span/span[@class = 'prices-amount']")]
        private IWebElement PreliminaryPrice;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'leadPriceOption EV paddingb2c']/div")]
        private IWebElement SelectFlight;
        //booknow button paddingB2C translate wasTranslated lastBrand
        [FindsBy(How = How.XPath, Using = "//div[@class = 'upsellSelectContent']/button[@class='booknow button paddingB2C translate wasTranslated']")]
        private IWebElement SelectPrice;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'btn-search']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'leadPriceOption EV paddingb2c']/div/div[2]/span/span/span[@class = 'prices-amount']")]
        private IWebElement CurrentPrice;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable dialog-error']")]
        private IWebElement ErrorForm;

        public SelectFlightsPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }

        public string GetPreliminaryPrice()
        {
            return PreliminaryPrice.Text;
        }

        public SelectFlightsPage SelectFlightClick()
        {
            SelectFlight.Click();
            return this;
        }

        public SelectFlightsPage SelectPriceClick()
        {
            SelectPrice.Click();
            return this;
        }

        public SelectFlightsPage ContinueButtonClick()
        {
            ContinueButton.Click();
            return this;
        }

        public bool ErrorFormIsDisplayed()
        {
            return ErrorForm.Displayed;
        }

        public string GetCurrentPrice()
        {
            return CurrentPrice.Text;
        }
    }
}
