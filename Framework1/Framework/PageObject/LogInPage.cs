using System;
using Framework.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Framework.PageObject
{
    public class LogInPage
    {
        private IWebDriver Driver;
        private WebDriverWait Wait;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'username']")]
        private IWebElement VelocityNumber;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'password']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = " //button[@id = 'btnKCLogin']")]
        private IWebElement LogInButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='Login']/div/div/div[@class = 'form-error-block']/div")]
        private IWebElement ErrorForm;

        public LogInPage(IWebDriver driver)
        {
            this.Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public LogInPage InputVelocityNumberAndBookingReference(User user)
        {
            VelocityNumber.SendKeys(user.VelocityNumber);
            Password.SendKeys(user.Password);
            return this;
        }

        public LogInPage LogInButtonClick()
        {
            LogInButton.Click();
            return this;
        }

        public bool ErrorFormIsEnabled()
        {
            return ErrorForm.Enabled;
        }

        public string GetUrl()
        {
            return this.Driver.Url;
        }
    }
}
