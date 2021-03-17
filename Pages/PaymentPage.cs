using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using OpenQA.Selenium.Support.UI;

namespace GoCityProject.Pages
{
    public class PaymentPage
    {
        IWebDriver driver;
        WebDriverWait wait;

        public PaymentPage(IWebDriver driver)

        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        }

        private IWebElement cardBtn => wait.Until(driver =>
         driver.FindElement(By.XPath("//span[text()='Debit / Credit Card']")));

        private IWebElement email => wait.Until(driver => driver.FindElement(By.Id("checkout-form-email")));

        private IWebElement checkBox => driver.FindElement(By.Name("checkoutSubscription"));
        private IWebElement cardNum => driver.FindElement(By.XPath("//*[@id='credit-card-number']"));
        private IWebElement month => driver.FindElement(By.XPath("//*[@id='expiration-month']"));////form[@novalidate="true"]
        private IWebElement year => driver.FindElement(By.Id("//*[@id='expiration-year']"));
        private IWebElement securityc => driver.FindElement(By.Id("cvv"));
        private IWebElement firstN => driver.FindElement(By.Name("firstName"));
        private IWebElement lastN => driver.FindElement(By.Name("lastName"));
        private IWebElement phoneN => driver.FindElement(By.Name("phoneNumber"));
        private IWebElement billingAdd => driver.FindElement(By.XPath("//input[@id='checkout-form-address']"));
        private IWebElement termsCondition => driver.FindElement(By.XPath("(//input[@type='checkbox'])[2]"));
        private IWebElement confirmOrderAndPay => driver.FindElement(By.XPath("//span[@data-testid='confirmOrderAndPay']"));


        public void enterAllInfo(string txtEmail, string cardNo, string mon, string y,
            string sec, string fn, string ln, string pn, string bi)
        {
            email.SendKeys(txtEmail);
            checkBox.Click();
            //cardNum.SendKeys(cardNo);
            //month.SendKeys(mon);
            //year.SendKeys(y);
            //securityc.SendKeys(sec);
            firstN.SendKeys(fn);
            lastN.SendKeys(ln);
            phoneN.SendKeys(pn);
            billingAdd.SendKeys(bi);
            termsCondition.Click();
            //confirmOrderAndPay.Click();
        }

    }
}

