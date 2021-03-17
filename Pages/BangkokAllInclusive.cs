
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Bogus;
using GoCityProject.CustomeMethods;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GoCityProject.Pages
{
    public class BangkokAllinclusive
    {
        IWebDriver driver;
        Helpers helpers;
        WebDriverWait wait;
        public BangkokAllinclusive(IWebDriver driver)
        {
            this.driver = driver;
            this.helpers = new Helpers(driver);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        private IWebElement passParam(string selecttxt, int firstIndex, int lastIndex, string passName) => 
            driver.FindElement(By.XPath($"//div[@data-index='{firstIndex}' and @tabindex='{lastIndex}']//div[contains(text(), '{passName}')]//parent::div/following-sibling::*[text()='{selecttxt}']"));

        private IWebElement orderSummaryWindow(string passName) =>
            driver.FindElement(By.XPath($"//div[@class='lc-cart--cart-order lc-font__regular']//div/div/span[text()='{passName}']"));

        private IWebElement passQuantityParam(string param, int index) => wait.Until(driver=>
            driver.FindElement(By.XPath($"(//div[text()='{param}']//following::*[@data-testid='cartItemIncrease'])[{index}]")));


        private IWebElement checkOutBtn =>
            driver.FindElement(By.XPath("//a[@class='lc-cart__purchase lc-font__regular ' or text()='Checkout']"));

        private IWebElement cartValue(string count) => 
            driver.FindElement(By.XPath($"(//div[@class='cart-icon__icon']//div[text()='{count}'])[1]"));
     
        private IWebElement reviewYourOrderDisplayed => driver.FindElement(By.CssSelector(".content__title"));

        public void ClickPassParam(string selecttxt, int firstIndex, int lastIndex, string passName)
        {
            //passParam(selecttxt, firstIndex, lastIndex, passName).scrollIntoView(driver);
            new Helpers(driver).Sleep(2);
            passParam(selecttxt, firstIndex, lastIndex, passName).Click();
        }

        public bool IsOrderSummaryWindowPassNameDisplayed(string passName) => orderSummaryWindow(passName).Displayed;

        public void ClickPassParam(string param, int index)
        {
            helpers.Sleep(3);
            passQuantityParam(param, index).Click();
            helpers.Sleep(3);
        }

        public void ClickCheckOutBtn() => checkOutBtn.Click();

        public string GetCartcount(string count)=> cartValue(count).Text;
        
        public string IsReviewYourOrderDisplayed() => reviewYourOrderDisplayed.Text;
    }
}
