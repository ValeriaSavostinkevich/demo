using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class HelpPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        public HelpPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public string GetUrlHelpPage()
        {
            return this.Driver.Url;
        }
    }
}
