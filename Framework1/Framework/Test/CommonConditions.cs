using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.PageObject;
using Framework.Driver;
using NUnit.Framework.Interfaces;
using log4net;
using log4net.Config;

namespace Framework.Test
{
    public class CommonConditions: TestListener
    {
        protected IWebDriver Driver;
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        [SetUp]
        public void OpenBrowser()
        {
            Driver = DriverSingleton.GetDriver();
            Log.Info("OpenBrowser");
        }

        [TearDown]
        public void CloseBrowser()
        {
            Log.Info("CloseBrowser");
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
                TestListener.OnTestFailure();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                TestListener.OnTestSuccess();

            DriverSingleton.CloseDriver();
        }
    }
}
