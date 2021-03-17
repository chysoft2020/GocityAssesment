using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GoCityProject.CustomeMethods
{
    public class Helpers
    {
        private IWebDriver driver;
        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Sleep(int sec)
        {
            Thread.Sleep(TimeSpan.FromSeconds(sec));
        }

        public void Implicitlywait(int sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }

        public void ExplicitWait(string element,locatorType type)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                Timeout = TimeSpan.FromSeconds(10),
                PollingInterval = TimeSpan.FromSeconds(3)
            };
            if (type == locatorType.Id)
                wait.Until(x => x.FindElement(By.Id(element)));
            else if(type == locatorType.Name)
                wait.Until(x => x.FindElement(By.Name(element)));
            else if (type == locatorType.XPath)
                wait.Until(x => x.FindElement(By.XPath(element)));
        }
    }

  
    public enum locatorType
    {
        Id,
        Name,
        XPath
    }

    public static class utility
    {
        /// <summary>
        /// Extension method to cick element
        /// </summary>
        /// <param name="element"></param>
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Extension method to scoll into view
        /// </summary>
        /// <param name="element"></param>
        /// <param name="driver"></param>
        public static void scrollIntoView(this IWebElement element, IWebDriver driver)
            => ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }

}
