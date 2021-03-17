using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoCityProject.Pages
{
    public class ReviewPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        public ReviewPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private IWebElement PassName(string txt) => wait.Until(driver=>
            driver.FindElement(By.XPath($"//div[contains(text(), '{txt}')]")));

        private IWebElement PricePassTotal(string price) =>
            driver.FindElement(By.XPath($"//div[@class='formatted-price'][.='{price}']"));

        private IWebElement PriceOrderTotal(string orderTotal) =>
            driver.FindElement(By.XPath($"//span[@class='lc-cart__prices-number ']//div[.='{orderTotal}']"));

        private IWebElement ClickdatePicker => driver.FindElement(By.XPath("//input[@class='travel-date--calendar travel-date-element hasDatepicker']"));
        private IWebElement Clickday(int day) => wait.Until(driver => 
        driver.FindElement(By.XPath($"//*[@id='ui-datepicker-div']//td[@data-handler='selectDay'][.='{day}']")));

        private IWebElement continueToPayment => driver.FindElement(By.XPath("(//a[@data-testid='continueToPayment'])[1]"));
        
   

        public string GetPassName(string txt) => PassName(txt).Text;
        public string GetPassPrice(string price) => PricePassTotal(price).Text;
        public string GetPassPriceTotal(string total) => PriceOrderTotal(total).Text;
        public void setDate(int day)
        {
            ClickdatePicker.Click();
            Clickday(day).Click();
        }

        public void clickContinueToPayement()
        {
            continueToPayment.Click();
        }

       
    }
}
