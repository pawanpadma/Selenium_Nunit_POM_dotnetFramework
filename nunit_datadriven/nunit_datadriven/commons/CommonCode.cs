using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_datadriven.commons
{
    public class CommonCode
    {
        public IWebDriver driver = InitBrowser.Getbrowser();

        public IWebElement ElementExists(By by, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement ele = wait.Until(ExpectedConditions.ElementExists(by));
            return ele;
        }

        public IWebElement ElementIsVisible(By by, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            IWebElement ele = wait.Until(ExpectedConditions.ElementIsVisible(by));
            return ele;
        }

        public IWebElement Fluentwait(By by, int wait)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(wait);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return fluentWait.Until(ele => ele.FindElement(by));
        }
    }
}