using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace VirginaustraliaTests.PageObject
{
    public class PlanningPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//*[@id='tln-nav-1071']/a")] //a[contains(., 'Book a flight')]
        private IWebElement BookAFlightButton;

        public PlanningPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public BookAFlightPage GoToBookAFlightPage()
        {
            BookAFlightButton.Click();
            return new BookAFlightPage(Driver);
        }
    }
}
