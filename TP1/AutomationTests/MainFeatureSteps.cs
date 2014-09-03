using System;
using TechTalk.SpecFlow;

namespace AutomationTests
{
    using AutomationTests.Infrastructure;
    using AutomationTests.Wrappers;

    using NUnit.Framework;

    using OpenQA.Selenium;

    [Binding]
    public class MainFeatureSteps : BaseScenario
    {
        private IndexPage indexPage;

        [Given(@"I have navigated to the site")]
        public void GivenIHaveNavigatedToTheSite()
        {
            this.indexPage = new IndexPage(this.WebDriver);
            this.WebDriver.Navigate().GoToUrl(BaseConfigurationResource.SiteAddress);
        }
        
        [Then(@"the title should be displayed on the screen")]
        public void ThenTheTitleShouldBeDisplayedOnTheScreen()
        {
            Assert.IsTrue(this.indexPage.IsElementVisible(By.TagName("header")));
        }
    }
}
