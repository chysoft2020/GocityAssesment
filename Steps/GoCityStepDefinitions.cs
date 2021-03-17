using BoDi;
using Bogus;
using Faker;
using GoCityProject.CustomeMethods;
using GoCityProject.Drivers;
using GoCityProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace GoCityProject.Steps
{
    [Binding]
    public class GoCityStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HomePage homePage;
        private readonly Helpers helpers;
        private readonly HowItWorksPage howItWorksPage;
        private readonly HelpPage helpPage;
        private readonly Covid19Page covid19Page;
        private readonly CityPassPage cityPassPage;
        private readonly BangkokAllinclusive bangkokAllinclusive;
        private readonly ReviewPage reviewPage;
        private readonly PaymentPage paymentPage;
        private IWebDriver driver;

        public GoCityStepDefinitions(IObjectContainer objectContainer)
        {
            this._scenarioContext = objectContainer.Resolve<ScenarioContext>();
            this.driver = objectContainer.Resolve<IWebDriver>();
            this.homePage = objectContainer.Resolve<HomePage>();
            this.helpers = objectContainer.Resolve<Helpers>();
            this.howItWorksPage = objectContainer.Resolve<HowItWorksPage>();
            this.helpPage = objectContainer.Resolve<HelpPage>();
            this.covid19Page = objectContainer.Resolve<Covid19Page>();
            this.cityPassPage = objectContainer.Resolve<CityPassPage>();
            this.bangkokAllinclusive = objectContainer.Resolve<BangkokAllinclusive>();
            this.reviewPage = objectContainer.Resolve<ReviewPage>();
            this.paymentPage = objectContainer.Resolve<PaymentPage>();
        }

        [Given(@"I am on GoCity homepage")]
        public void GivenIAmOnGoCityHomepage()
        {
            homePage.GotoSite();
        }

        [When(@"I cick on the video play button")]
        public void WhenICickOnTheVideoFrame()
        {
            helpers
               .Implicitlywait(2);
            homePage.SwitchToIframe();
            string defaultCount = homePage.GetTimerValue();
            homePage.ClickPlayOnVideoFrame();
            helpers
                .Sleep(5);
        }

        [Then(@"I can see the video playinga nd count greater than '(.*)'")]
        public void ThenICanSeeTheVideoPlaying(string defaultCount)
        {
            homePage.PauseVidePlayBack();
            string actualCount = homePage.GetTimerValue();
            Assert.AreNotEqual(defaultCount, actualCount, 
                "Are equal");
        }

        [When(@"I navigate to how it works page")]
        public void WhenINavigateToHowItWorksPage()
        {
            homePage.clickHowitworks();
        }

        [Then(@"I am on '(.*)' page")]
        public void ThenIAmOnHowItWorksPage(string expectedTxt)
        {
            Assert.AreEqual(expectedTxt, 
                howItWorksPage.GetText(expectedTxt), "Text not equal");
        }

        [When(@"I navigate to help page")]
        public void WhenINavigateToHelpPage()
        {
            homePage.clickHelp();
        }

        [When(@"I navigate to covid 19 page")]
        public void WhenINavigateToCovidPage()
        {
            homePage.clickCovid19();
        }

        [When(@"I click city name '(.*)'")]
        public void WhenISelectCityName(string cityName)
        {
            homePage.clickCity(cityName);
        }

        [Then(@"Go '(.*)' page is displayed")]
        public void ThenPageIsDisplayed(string expectedTxt)
        {
            bool txt = cityPassPage.IsCityTextDisplayed(expectedTxt);
            Assert.True(cityPassPage.IsCityTextDisplayed(expectedTxt), 
                $"{expectedTxt} not displayed on page");
        }

        [When(@"I click on '(.*)'")]
        public void WhenIClickOn(string txt)
        {
            cityPassPage.clickBuyBtn(txt);
        }

        [When(@"I click on '(.*)' index (.*)")]
        public void WhenIClickOn(string txt, int index)
        {
            cityPassPage.clickBuyNowBtn(txt, index);
        }

        [When(@"I '(.*)' pass of index (.*), '(.*)' of name '(.*)'")]
        public void ThenIClickOnAtIndexOfName(string selecttxt, int firstIndex, int lastIndex, string passName)
        {
            bangkokAllinclusive.ClickPassParam(selecttxt, firstIndex, lastIndex, passName);
        }

        [Then(@"Order summary is displayed with pass '(.*)'")]
        public void ThenOrderSummaryIsDisplayedWithPass(string passName)
        {
            bangkokAllinclusive.IsOrderSummaryWindowPassNameDisplayed(passName);
        }

        [When(@"I click '(.*)' pass quantity index (.*)")]
        public void WhenIClickPassQuantity(string paramAlias, int index)
        {
            bangkokAllinclusive.ClickPassParam(paramAlias, index);
        }

        [When(@"I click checkout")]
        public void ThenIClickCheckout()
        {
            bangkokAllinclusive.ClickCheckOutBtn();
        }

        [Then(@"I vaidate pass count is '(.*)'")]
        public void ThenIVaidatePassCountIs(string cartCount)
        {
            var result = bangkokAllinclusive.GetCartcount(cartCount);
            bangkokAllinclusive.GetCartcount(cartCount);
        }

        [Then(@"'(.*)' page is displayed")]
        public void ThenIsDisplayed(string reviewYourOrder)
        {
            var txt = bangkokAllinclusive.IsReviewYourOrderDisplayed();
            Assert.True(txt.Equals(reviewYourOrder), $"{reviewYourOrder} not displayed on page");
        }

        [Then(@"the following pass info is displayed:")]
        public void ThenTheFollowingPassInfoIsDisplayed(Table table)
        {
            IEnumerable<dynamic> infos = table.CreateDynamicSet();
            foreach (var info in infos)
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(info.AdultPassName,
                        reviewPage.GetPassName(table.Rows[0]["AdultPassName"]));
                    Assert.AreEqual(info.ChildPassName,
                        reviewPage.GetPassName(table.Rows[0]["ChildPassName"]));
                    Assert.AreEqual(info.TotalAdultPricePerPass,
                        reviewPage.GetPassPrice(table.Rows[0]["TotalAdultPricePerPass"]));
                    Assert.AreEqual(info.TotalChildPricePerPass,
                        reviewPage.GetPassPrice(table.Rows[0]["TotalChildPricePerPass"]));
                    Assert.AreEqual(info.OrderTotal,
                        reviewPage.GetPassPriceTotal(table.Rows[0]["OrderTotal"]));
                });

            }

        }

        [When(@"I select day (.*) from the current date")]
        public void WhenISelectDayFromTheCurrentDate(int day)
        {
            reviewPage.setDate(day);
        }

        [When(@"I click on Continue to payment")]
        public void ThenIClickOn()
        {
            reviewPage.clickContinueToPayement();
        }

        [When(@"I enter all the required informations")]
        public void WhenIEnterAllTheRequiredInformations()
        {
            
           
            string email = Internet.Email();
            string cNumber = "987654";
            string month = "July";
            string year =  "2021";
            string SCode = Identification.SocialSecurityNumber();
            string fname = Name.First();
            string Lname = Name.Last();
            string Pnumber = Phone.Number();
            string Binfo = Address.StreetAddress() + Address.City();
            paymentPage.enterAllInfo(
                email, cNumber, month, year, SCode, fname, Lname, Pnumber, Binfo);
        }

    }
}
