using GoCityProject.CustomeMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoCityProject.Pages
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement videoFrame =>
            driver.FindElement(By.XPath("//button[@aria-label='Play']"));

        private IWebElement videoFrameTimer => driver.FindElement(By.XPath($"//span[@class='ytp-time-current']"));

        private IWebElement iframe => driver.FindElement(By.XPath("//iframe"));

        private IWebElement pauseVideo => driver.FindElement(By.XPath("//button[@class='ytp-play-button ytp-button']"));

        private IWebElement Howitworks => driver.FindElement(By.LinkText("How it works"));

        private IWebElement Help => driver.FindElement(By.LinkText("Help"));

        private IWebElement Covid19 => driver.FindElement(By.LinkText("COVID-19"));

        private IWebElement SelectCity(string city) =>
            driver.FindElement(By.XPath($"//li[@class='destination-list--item']//div/a[@title='{city}']"));


        public void GotoSite() => driver.Navigate().GoToUrl(Utilities.BaseUrl);
        public void SwitchToIframe() => driver.SwitchTo().Frame(iframe);
        public void ClickPlayOnVideoFrame() => videoFrame.Click();
        public string GetTimerValue() => videoFrameTimer.Text;
        public void PauseVidePlayBack() => pauseVideo.Click();
        public void clickHowitworks() => Howitworks.Click();
        public void clickHelp() => Help.Click();
        public void clickCovid19() => Covid19.Click();
        public void clickCity(string city)
        {
            SelectCity(city).scrollIntoView(driver);
            SelectCity(city).Click();
        }
    }
}
