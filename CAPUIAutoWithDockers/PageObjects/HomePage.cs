using CAPUIAutoWithDockers.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CAPUIAutoWithDockers.PageObjects
{
    public class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//span[text()='Customer Management']")]
        protected IWebElement CustomerManagement { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='User Management']")]
        protected IWebElement UserManagement { get; set; }


        private readonly IWebDriver _driver;
        WebDriverHelper Driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Driver = new WebDriverHelper(_driver);
        }

        public void ClickCustomerManagement()
        {
            Driver.ClickOn(CustomerManagement);
            //CustomerManagement.Click();
        }

        public void ClickUserManagement()
        {
            Driver.ClickOn(CustomerManagement);
            //UserManagement.Click();
        }
    }
}
