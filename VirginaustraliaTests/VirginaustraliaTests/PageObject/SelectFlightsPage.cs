using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    class SelectFlightsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //   Brisbane (BNE)
        //Adelaide (ADL)
        public SelectFlightsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@id = 'yui_3_1_2_3_157410097521915646']")]
        IWebElement PreliminaryPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id = 'yui_3_1_2_3_157410015628411302']")]
        IWebElement SelectFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id = 'yui_3_1_2_3_157410097521915716']")]
        IWebElement SelectPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id = 'btn-search']")]
        IWebElement ContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id = 'yui_3_1_2_1_15741013216802798']")]
        IWebElement CurrentPrice { get; set; }

        public string GetPreliminaryPrice()
        {
            return PreliminaryPrice.Text;
        }

        public string GetCurrentPrice()
        {
            SelectFlight.Click();
            SelectPrice.Click();
            ContinueButton.Click();
            return CurrentPrice.Text;
        }
    }
}
