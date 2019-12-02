using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using Framework.PageObject;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Framework.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver Driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if(null == Driver)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        Driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        Driver = new ChromeDriver();
                        break;
                }
                Driver.Manage().Window.Maximize();
            }
            return Driver;
        }

        public static void CloseDriver()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}
