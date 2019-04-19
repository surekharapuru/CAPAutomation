using CAPUIAutoWithDockers.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CAPUIAutoWithDockers.PageObjects
{
    public class NewCustomerPage
    {
        // ==> Old Style of writing Page Objects 

        /*[FindsBy(How = How.Name, Using = "anElementName", Priority = 0)]
        [FindsBy(How = How.Name, Using = "differentElementName", Priority = 1)]

        [FindsByAll]
        [FindsBy(How = How.TagName, Using = "input", Priority = 0)]
        [FindsBy(How = How.Id, Using = "elementId", Priority = 1)]*/

        /*[FindsBy(How = How.XPath, Using = "(//span[contains(text(),'Add Customer')])[3]")]
        protected IWebElement AddCustomer { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-3']")]
        protected IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='mat-input-4']")]
        protected IWebElement Description { get; set; }

        [FindsBy(How = How.XPath, Using = "//mat-select[@id='mat-select-0']")]
        protected IWebElement IsolationLevel { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Cluster']")]
        protected IWebElement Cluster { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Namespace']")]
        protected IWebElement NameSpace { get; set; }

        [FindsBy(How = How.XPath, Using = "//mat-select[@id='mat-select-1']")]
        protected IWebElement Size { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Small']")]
        protected IWebElement Small { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Medium']")]
        protected IWebElement Medium { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Large']")]
        protected IWebElement Large { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[text()='Save'])[2]")]
        public IWebElement Save { get; set; }*/


        private readonly IWebDriver _driver;
        WebDriverHelper Driver;

        public NewCustomerPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Driver = new WebDriverHelper(_driver);
        }
        IWebElement AddCustomer => _driver.FindElement(By.XPath("(//span[contains(text(),'Add Customer')])[3]"));
        IWebElement Name => _driver.FindElement(By.XPath("//input[@id='mat-input-3']"));
        IWebElement Description => _driver.FindElement(By.XPath("//input[@id='mat-input-4']"));
        IWebElement IsolationLevel => _driver.FindElement(By.XPath("//mat-select[@id='mat-select-0']"));
        IWebElement Cluster => _driver.FindElement(By.XPath("//span[text()='Cluster']"));
        IWebElement NameSpace => _driver.FindElement(By.XPath("//span[text()='Namespace']"));
        IWebElement Size => _driver.FindElement(By.XPath("//mat-select[@id='mat-select-1']"));
        IWebElement Small => _driver.FindElement(By.XPath("//span[text()='Small']"));
        IWebElement Medium => _driver.FindElement(By.XPath("//span[text()='Medium']"));
        IWebElement Large => _driver.FindElement(By.XPath("//span[text()='Large']"));
        public IWebElement Save => _driver.FindElement(By.XPath("(//span[text()='Save'])[2]"));
        public IWebElement CancelBtn => _driver.FindElement(By.XPath("(//div[1]/button/span/mat-icon)[3]"));

       

        public void AddNewCustomer(dynamic details)
        {
            Driver.ClickOn(AddCustomer);
            Driver.EnterText(Name, details.Name);
            Driver.EnterText(Description, details.Description);
            Driver.ClickOn(IsolationLevel);

            /*AddCustomer.Click();
            Name.SendKeys(details.Name);
            Description.SendKeys(details.Description);
            IsolationLevel.Click();*/

            switch (details.IsolationLevel.ToLower())
            {
                case "cluster":
                    Driver.ClickOn(Cluster);
                    //Cluster.Click();
                    break;
                case "namespace":
                    Driver.ClickOn(NameSpace);
                    //NameSpace.Click();
                    break;
                default:
                    Driver.ClickOn(Cluster);
                    //Cluster.Click();
                    break;
            }

            Size.Click();
            switch (details.Size.ToLower())
            {
                case "small":
                    Driver.ClickOn(Small);
                    //Small.Click();
                    break;
                case "medium":
                    Driver.ClickOn(Medium);
                    //Medium.Click();
                    break;
                case "large":
                    Driver.ClickOn(Large);
                    //Large.Click();
                    break;
                default:
                    Driver.ClickOn(Small);
                    //Small.Click();
                    break;
            }

        }
    }
}
