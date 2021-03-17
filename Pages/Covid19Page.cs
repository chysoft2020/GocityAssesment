using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoCityProject.Pages
{
    public class Covid19Page
    {
        IWebDriver driver;
        public Covid19Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement HeaderTxt(string txt) => 
            driver.FindElement(By.XPath($"//ol[@class='breadcrumb']//li/a[text()='Home']//following::li[contains(text(), '{txt}')]"));


        public string GetText(string txt) => HeaderTxt(txt).Text;

    }
}
