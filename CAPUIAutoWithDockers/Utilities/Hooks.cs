using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using CAPUIAutoWithDockers.Utilities;
using System.Configuration;
using System.Reflection;

namespace GridDemo1.Utilities
{
    [Binding]
    public sealed class Hooks : BaseTest
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly IObjectContainer objectContainer;
        new IWebDriver webDriver;
        WebDriverHelper Driver;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }


        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            webDriver = GetRemoteDriver(AppSetting("browser").ToString());
            //webDriver = GetDriver(AppSetting("browser").ToString());
            Driver = new WebDriverHelper(webDriver);           
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
            Driver.TurnOnWait(60);
          // webDriver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(4000);
            Driver.CloseDriver();
        }
    }

    public abstract class BaseTest
    {
        protected IWebDriver webDriver;

        /// <summary>
        /// Create and returns the WebDriver instance
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /*// <param name="BaseUrl">Application / Test Env value which is specified in App.config file</param>*/
        /// <returns>IWebDriver instance</returns>
        public IWebDriver GetDriver(string browserType)
        {
            /*var capability = DesiredCapabilities.Chrome();
            if (_driver == null)
            {
                _driver = new RemoteWebDriver(new Uri("http://0.0.0.0:4444/wd/hub/"), capability, TimeSpan.FromSeconds(600));
            }

            return _driver;*/

            switch (browserType)
            {
                case "chrome":
                case "CHROME":
                    ChromeOptions option = new ChromeOptions();
                    //option.AddArgument("--headless");
                    webDriver = new ChromeDriver(option);
                    break;

                case "firefox":
                case "ff":
                case "FIREFOX":
                case "Firefox":
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    FirefoxOptions FFOptions = new FirefoxOptions();
                    FFOptions.AcceptInsecureCertificates = true;
                    webDriver = new FirefoxDriver(FFOptions);
                    //_objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);
                    break;

                case "InternetExplorer":
                case "Internet Explorer":
                case "IE":
                case "INTERNETEXPLORER":
                case "INTERNET EXPLORER":
                    //var options = new IEOptions();
                    // options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    webDriver = new InternetExplorerDriver();
                    break;

                default:
                    ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("--headless");
                    webDriver = new ChromeDriver(options);
                    break;
            }

            Thread.Sleep(2000);
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        /// <summary>
        /// Create and returns the RemoteWebDriver instance
        /// </summary>
        /// <param name="browserType">Browser key value which is specified in App.config file</param>
        /*// <param name="BaseUrl">Application / Test Env value which is specified in App.config file</param>*/
        /// <returns>IWebDriver instance</returns>
        public IWebDriver GetRemoteDriver(string browserType)
        {
            /*var capability = DesiredCapabilities.Chrome();
            if (_driver == null)
            {
                _driver = new RemoteWebDriver(new Uri("http://0.0.0.0:4444/wd/hub/"), capability, TimeSpan.FromSeconds(600));
            }

            return _driver;*/

            switch (browserType)
            {
                case "chrome":
                case "CHROME":
                case "Chrome":
                    ChromeOptions ChromeOptions = new ChromeOptions();
                    ChromeOptions.AddArguments("--start-maximized");
                    //option.AddArgument("--headless");
                    //webDriver = new ChromeDriver(option);
                    webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), ChromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;

                case "firefox":
                case "ff":
                case "FIREFOX":
                case "Firefox":
                    var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    service.HideCommandPromptWindow = true;
                    service.SuppressInitialDiagnosticInformation = true;
                    FirefoxOptions FFOptions = new FirefoxOptions();
                    FFOptions.AcceptInsecureCertificates = true;
                    webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), FFOptions.ToCapabilities(), TimeSpan.FromSeconds(600));

                    //webDriver = new FirefoxDriver(service);
                    //_objectContainer.RegisterInstanceAs<RemoteWebDriver>(webDriver);
                    break;

                case "InternetExplorer":
                case "Internet Explorer":
                case "IE":
                case "INTERNETEXPLORER":
                case "INTERNET EXPLORER":
                    //var options = new IEOptions();
                    // options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //webDriver = new InternetExplorerDriver();
                    break;

                default:
                    ChromeOptions DefaultChromeOptions = new ChromeOptions();
                    //options.AddArgument("--headless");
                    webDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), DefaultChromeOptions.ToCapabilities(), TimeSpan.FromSeconds(600));
                    break;
            }

            Thread.Sleep(4000);
           // webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// If the setting is not specified the default value is returned.
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <param name="defaultValue">The default value of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSettingOrDefault(string key, string defaultValue)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(appSetting))
                appSetting = defaultValue;

            return appSetting;
        }

        /// <summary>
        /// Looks up the application setting for the specified key. 
        /// </summary>
        /// <param name="key">The key of the application setting</param>
        /// <returns>A string that holds the value of the setting.</returns>
        public string AppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            return appSetting;
        }

    }
}
