using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoCityProject.Pages
{
    public class CityPassPage
    {
        IWebDriver driver;
        public CityPassPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement cityPassName(string txt) =>
            driver.FindElement(By.XPath($"//a[@title='Home']//img[contains(@src, '{txt}' )]"));

        private IWebElement buyNowBtn(string txt, int index) => driver.FindElement(By.XPath($"(//a[text()='{txt}'])[{index}]"));

        private IWebElement buyBtn(string txt) => driver.FindElement(By.XPath($"//a[text()='{txt}']"));


        public bool IsCityTextDisplayed(string txt) => 
            cityPassName(txt).Displayed;

        public void clickBuyNowBtn(string txt, int index) => buyNowBtn(txt, index).Click();

        public void clickBuyBtn(string txt) => buyBtn(txt).Click();

    }
}
