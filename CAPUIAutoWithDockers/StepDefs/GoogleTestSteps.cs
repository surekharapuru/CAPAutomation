using CAPUIAutoWithDockers.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CAPUIAutoWithDockers.StepDefs
{
    [Binding]
    public class GoogleTestSteps
    {
        private readonly ScenarioContext context;
        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;

        public GoogleTestSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }

        [Given(@"enter google url")]
        public void GivenEnterGoogleUrl()
        {
            Driver.Navigate("https://www.google.com");
        }

        [Given(@"enter conduent website url")]
        public void GivenEnterConduentWebsiteUrl()
        {
            Driver.Navigate("https://www.conduent.com");
        }


        [Then(@"the result should be have google screen")]
        public void ThenTheResultShouldBeHaveGoogleScreen()
        {
          //Assert.IsTrue(webDriver.Title.ToString().Contains("test"));
           // Thread.Sleep(20000);
        }
    }
}
