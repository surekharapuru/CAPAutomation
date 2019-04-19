using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAPUIAutoWithDockers.Utilities
{
    public class WebDriverHelper
    {
        IWebDriver WebDriver;
        public WebDriverHelper(IWebDriver driver)
        {
            this.WebDriver = driver;
        }

        public void TakeScreenshot(string filePath)
        {
            try
            {
                ITakesScreenshot screenshotDriver = WebDriver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseDriver()
        {
            //WebDriver.Close();
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        /// <summary>
        /// Click on WebElement
        /// </summary>      
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void ClickOn(IWebElement element)
        {
            try
            {
                element.Click();
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Enter text into textbox
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToEnter">Text to be entered into text box</param>
        /// <return> N/A </return>
        public void EnterText(IWebElement element, string textToEnter)
        {
            try
            {
                element.Click();
                Thread.Sleep(1000);
                //element.Clear();
                //Keyboard.Instance.Enter(textToEnter);       
                element.SendKeys(textToEnter);
                //SendKeys.SendWait(textToEnter);
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Get Text from the WebElement
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetText(IWebElement element)
        {
            try
            {
                return element.Text.ToString();
            }

            catch (Exception exception)
            {
                throw exception;
            }
        }


        /// <summary>
        /// Switch to Iframe using Index
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToIFrameByFrameIndex(int frameIndex)
        {
            try
            {
                WebDriver.SwitchTo().Frame(frameIndex);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Switch to Iframe using Frame Name
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToIFrameByFrameName(string frameName)
        {
            try
            {
                WebDriver.SwitchTo().Frame(frameName);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Switch Out of Iframe
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchOutOfIFrame()
        {
            try
            {
                WebDriver.SwitchTo().DefaultContent();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Returns true if Element is displayed in HTML / DOM
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool IsDisplayed(IWebElement element)
        {
            bool result;

            try
            {
                result = element.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }


        /// <summary>
        /// Returns true if Element is Enabled
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool IsEnabled(IWebElement element)
        {
            return element.Enabled;
        }


        /// <summary>
        /// Select the Check Box
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void SelectCheckBox(IWebElement element)
        {
            try
            {
                if (!element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// UnSelect the Check Box
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void UnSelectCheckBox(IWebElement element)
        {
            try
            {
                if (element.Selected)
                {
                    element.Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get attribute Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="attributeName">Attribute name to retrieve</param>
        /// <return> string </return>
        public string GetAttribute(IWebElement element, string attributeName) //String attributeName
        {
            //MessageBox.Show( String.Format( "GetAttribute: {0}", args[0].ToString() ) );
            //String attributeName = (String)args[0];
            //MessageBox.Show( "Entered getAttribute" );
            //MessageBox.Show( SELENIUMBROWSER.Driver.FindElement(By.XPath(this.Locator)).GetAttribute(attributeName) ); // REMOVE THIS ASAP
            return element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Get CSS Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="propertyName">CSS property name like color, font-size, font-weight etc.,</param>
        /// <return> string </return>
        public string GetCssValue(IWebElement element, string propertyName)
        {
            try
            {
                return element.GetCssValue(propertyName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // System.Drawing.Point
        /// <summary>
        /// Get Location of the Element
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Point </return>
        public Point GetLocation(IWebElement element)
        {
            try
            {
                return element.Location;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns true if element is selected
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Boolean </return>
        public bool GetSelected(IWebElement element)
        {
            try
            {
                return element.Selected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Size of the Element
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> Size </return>
        public Size GetSize(IWebElement element)
        {
            return element.Size;
        }

        /// <summary>
        /// Get HTML tag name
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetTagName(IWebElement element)
        {
            return element.TagName;
        }


        /// <summary>
        /// Wait until element is visible
        /// </summary>        
        /// <return> N/A </return>
        public void WaitForElementVisible(By by, int timeOutInSeconds)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception)
            {
                Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.Seconds);
            }
            finally
            {
                stopwatch.Stop();
            }
        }

        /// <summary>
        /// Select Dropdown using text
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToSelect">Text to Select</param>
        /// <return> N/A </return>
        public void SelectDropDownByText(IWebElement element, string textToSelect)
        {
            try
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByText(textToSelect);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Select Dropdown using Index
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="indexToSelect">Index of the element to Select</param>       
        /// <return> N/A </return>
        public void SelectDropDownByIndex(IWebElement element, int indexToSelect)
        {
            try
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByIndex(indexToSelect);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Select Dropdown using Value
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="valueToSelect">Value of the element to Select</param>
        /// <return> N/A </return>
        public void SelectDropDownByValue(IWebElement element, string valueToSelect)
        {
            try
            {
                SelectElement selectElement = new SelectElement(element);
                selectElement.SelectByValue(valueToSelect);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get all Options displayed in the DropDown
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> List of IWebElement </return>
        public IList<IWebElement> GetAllOptionsInDropDown(IWebElement element)
        {
            try
            {
                SelectElement selectElement = new SelectElement(element);
                return selectElement.AllSelectedOptions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Selected Value from the DropDown
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> string </return>
        public string GetSelectedValueFromDropDown(IWebElement element)
        {
            try
            {
                return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Maximizes the browser.
        /// </summary>        
        public void Maximize()
        {
            try
            {
                WebDriver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Bring Browser to focus.
        /// </summary>        
        public void BrowserFocus()
        {
            try
            {
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("window.focus();");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Opens a New Tab in the browser with specified URL
        /// </summary>
        /// <param name="url">URL to navigate</param>
        /// <return> N/A </return>
        public void OpenBrowserInNewTab(string url)
        {
            try
            {
                WebDriver.FindElement(By.CssSelector("body")).SendKeys(OpenQA.Selenium.Keys.Control + "t");
                WebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Switch to Tab using Index
        /// </summary>
        /// <param name="tabIndex">Tab Index</param>
        /// <return> N/A </return>
        public void SwitchToTab(int tabIndex)
        {
            try
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles[tabIndex]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Deletes Browser Cookies
        /// </summary>        
        /// <return> N/A </return>
        public void DeleteBrowserCookies()
        {
            try
            {
                WebDriver.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Implicit Wait for the driver
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void TurnOnWait(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the amount of time to wait for a page load to complete before throwing an error. 
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void SetPageLoadTimeOut(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the amount of time to wait for an asynchronous script to finish execution before throwing an error
        /// </summary>
        /// <param name="timeInSeconds">Time in Seconds</param>
        /// <return> N/A </return>
        public void SetScriptTimeOut(int timeInSeconds)
        {
            try
            {
                WebDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(timeInSeconds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Navigate to Specified URL
        /// </summary>
        /// <param name="url">URL to Navigate</param>
        /// <return> N/A </return>
        public void Navigate(string url)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Text from the Alert Box
        /// </summary>        
        /// <return> string - Text from the AlertBox </return>
        public string AlertText()
        {
            try
            {
                return WebDriver.SwitchTo().Alert().Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Accept the Alert Box
        /// </summary>        
        /// <return> N/A </return>
        public void AcceptAlert()
        {
            try
            {
                WebDriver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dismiss the Alert Box
        /// </summary>        
        /// <return> N/A </return>
        public void DismissAlert()
        {
            try
            {
                WebDriver.SwitchTo().Alert().Dismiss();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Sets the username and password in the Alert
        /// </summary>        
        /// <return> N/A </return>
        public void SetAuthenticationOnAlert(string username, string password)
        {
            try
            {
                WebDriver.SwitchTo().Alert().SetAuthenticationCredentials(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return True if JavaScript Alert is present on the page otherwise false
        /// </summary>        
        /// <return> Boolean </return>
        public bool IsAlertPresent()
        {
            try
            {
                WebDriver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Clear the text in TextBox
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <return> N/A </return>
        public void Clear(IWebElement element)
        {
            element.Clear();
        }

        /*/// <summary>
        /// Enter text using Keyboard
        /// </summary>    
        /// <param name="textToEnter">Text to be entered into text box</param>
        /// <return> N/A </return>
        public void EnterTextKeyBoard(string textToEnter)
        {
            Keyboard.Instance.Enter(textToEnter);
            //SendKeys.SendWait(textToEnter);
        }*/

        /// <summary>
        /// Clear the text in text box and will enter new text 
        /// </summary>
        /// <param name="element">IWebElement</param>
        /// <param name="textToEnter">Text to ne modified and entered into text box</param>
        /// <return> N/A </return>
        public void ModifyText(IWebElement element, string textToEnter)
        {
            element.Clear();
            Thread.Sleep(1000);
            EnterText(element, textToEnter);
        }


        static Dictionary<dynamic, dynamic> BrowserWindows = new Dictionary<dynamic, dynamic>();

        /// <summary>
        /// Switch to another browser window 
        /// </summary>        
        /// <return> N/A </return>
        public void SwitchToNewBrowserWindow()
        {
            dynamic currentWindow = WebDriver.CurrentWindowHandle;

            if (!BrowserWindows.ContainsKey(currentWindow)) BrowserWindows.Add(currentWindow, null);

            foreach (dynamic eachWindow in WebDriver.WindowHandles)
                if (!BrowserWindows.ContainsKey(eachWindow))
                {
                    BrowserWindows.Add(eachWindow, currentWindow);
                    WebDriver.SwitchTo().Window(eachWindow);
                }
        }

     
        /// <summary>
        /// WebDriverWaitUsingPolling
        /// </summary>
        /// <param name="element"></param>
        /// <param name="atributeName"></param>
        /// <param name="value"></param>
        public void WebDriverWaitUsingPolling(IWebElement element, string atributeName, string value, int timeOutInMin = 2, int timeIntervalInMilliSec = 250)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(timeOutInMin);
            wait.PollingInterval = TimeSpan.FromMilliseconds(timeIntervalInMilliSec);
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String attrib = element.GetAttribute(atributeName);
                if (attrib.Contains(value))
                {
                    return true;
                }
                return false;
            });
            wait.Until(waiter);
        }


        /// <summary>
        /// Get WebDriver instance
        /// </summary>        
        /// <return> string </return>
        public IWebDriver GetDriver()
        {
            return WebDriver;
        }
    }
}
