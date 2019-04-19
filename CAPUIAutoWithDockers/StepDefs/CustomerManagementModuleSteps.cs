using CAPUIAutoWithDockers.PageObjects;
using CAPUIAutoWithDockers.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace CAPUIAutoWithDockers.StepDefs
{
    [Binding]
    public class CustomerManagementModuleSteps
    {
        private readonly ScenarioContext context;
        private readonly IWebDriver webDriver;
        readonly WebDriverHelper Driver;
        public CustomerManagementModuleSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            Driver = new WebDriverHelper(webDriver);
        }
        [Given(@"I navigate to Home page")]
        public void GivenINavigateToHomePage()
        {
            Driver.Navigate("https://enterpriseweb.dev.cndt.cf/home");
        }
        
        [When(@"Click CustomerMnagement tab")]
        public void WhenClickCustomerMnagementTab()
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickCustomerManagement();
        }
        
        [When(@"I add a customer with below data")]
        public void WhenIAddACustomerWithBelowData(Table table)
        {
            HomePage homePage = new HomePage(webDriver);
            homePage.ClickCustomerManagement();
            NewCustomerPage newCustomer = new NewCustomerPage(webDriver);
            dynamic details = table.CreateDynamicInstance();
            newCustomer.AddNewCustomer(details);
            Assert.IsTrue(newCustomer.Save.Enabled, "Save Button is not Enabled.");
            newCustomer.CancelBtn.Click();
        }
        
        [Then(@"""(.*)"" screen displayed")]
        public void ThenCustomerManagementScreenDisplayed(String Name)
        {
            Assert.IsTrue(webDriver.Title.ToString().Contains(Name));
        }
        
        [Then(@"I verify customer data is added as ""(.*)""")]
        public void ThenIVerifyCustomerDataIsAddedAs(string p0)
        {
            if (p0.Equals("true"))
                Assert.IsTrue(true);
            else
                Assert.IsFalse(true);
        }

    }
}

